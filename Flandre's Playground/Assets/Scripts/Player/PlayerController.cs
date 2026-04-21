using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Events to raise
    public UnityEvent flipHitbox;
    public UnityEvent gameOver;

    // Constants
    public GameConstants gameConstants;
    public BoolVariable faceRight;
    public BoolVariable cantJump;
    public BoolVariable cantMove;
    float jumpForce;
    float decayRate;
    float speed;
    float maxSpeed;
    float attackCooldown;
    float flipDelay;
    private bool onGroundState = true;
    private bool moving = false;

    [System.NonSerialized]
    public bool alive = true;


    // Flandre Components
    private SpriteRenderer flanSprite;
    private Rigidbody2D flanBody;
    private Animator flanAnimator;
    private AudioSource flanAudio;
    public AudioSource flanDeathAudio;
    // Start is called before the first frame update
    void Start()
    {
        // Extract Constants
        jumpForce = gameConstants.jumpForce;
        decayRate = gameConstants.decayRate;
        speed = gameConstants.speed;
        maxSpeed = gameConstants.maxSpeed;
        attackCooldown = gameConstants.attackCooldown;
        flipDelay = gameConstants.flipDelay;

        // Get Components
        flanSprite = GetComponent<SpriteRenderer>();
        flanBody = GetComponent<Rigidbody2D>();
        flanAnimator = GetComponent<Animator>();
        flanAudio = GetComponent<AudioSource>();

        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        alive = true;

        faceRight.SetValue(false);
    }
    public void GameRestart()
    {

    }

    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 << 11);
    void OnCollisionEnter2D(Collision2D col)
    {
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
        }
    }

    // Damaged Player
    public void DamagePlayer()
    {
        if (alive)
        {
            flanAnimator.SetTrigger("gotHit");
            flanDeathAudio.PlayOneShot(flanDeathAudio.clip);
            alive = false;
            gameOver.Invoke();
        }
    }

    // Movement
    public void MoveCheck(int value)
    {
        State flanState = this.GetComponent<FlanStateController>().currentState;
        if (string.Equals(flanState.name, "Flandre", System.StringComparison.OrdinalIgnoreCase) && !cantMove.Value)
        {
            if (value == 0)
            {
                moving = false;
            }
            else
            {
                FlipFlanSprite(value);
                moving = true;
                Move(value);
            }
        }

    }
    void FlipFlanSprite(int value)
    {
        if (value == -1 && faceRight.Value)
        {
            faceRight.Toggle();
            flipHitbox.Invoke();
            // flanSprite.flipX = false;
            StartCoroutine(FlipSprite());
            if (flanBody.velocity.x > 0.05f)
                flanAnimator.SetTrigger("onTurn");

        }
        else if (value == 1 && !faceRight.Value)
        {
            faceRight.Toggle();
            flipHitbox.Invoke();
            // flanSprite.flipX = true;
            StartCoroutine(FlipSprite());
            if (flanBody.velocity.x < -0.05f)
                flanAnimator.SetTrigger("onTurn");
        }
    }
    IEnumerator FlipSprite()
    {
        yield return new WaitForSeconds(flipDelay);
        flanSprite.flipX = faceRight.Value;
    }
    void Move(int value)
    {
        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (flanBody.velocity.magnitude < maxSpeed)
            flanBody.AddForce(movement * speed);
    }

    // Jumping
    IEnumerator DoJump()
    {
        // Debug.Log("Jump");
        onGroundState = false;
        // Jump Audio
        flanAudio.PlayOneShot(flanAudio.clip);
        // the initial jump
        flanBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        yield return null;

        //can be any value, maybe this is a start ascending force, up to you
        float currentForce = jumpForce;

        while (Input.GetKey(KeyCode.W) && currentForce > 0)
        {
            flanBody.AddForce(Vector2.up * currentForce, ForceMode2D.Impulse);

            currentForce -= decayRate * Time.deltaTime;

            yield return null;
        }
    }

    // FixedUpdate is called 50 times a second
    void FixedUpdate()
    {
        if (alive && moving)
        {
            Move(faceRight.Value == true ? 1 : -1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        flanAnimator.SetFloat("xSpeed", Mathf.Abs(flanBody.velocity.x));
        State flanState = this.GetComponent<FlanStateController>().currentState;
        if (Input.GetKeyDown(KeyCode.W) && onGroundState && !cantJump.Value && string.Equals(flanState.name, "Flandre", System.StringComparison.OrdinalIgnoreCase))
        {
            StartCoroutine(DoJump());
        }
    }
}
