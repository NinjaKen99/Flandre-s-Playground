using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFairyController : EnemyController
{
    // Added Variables
    public BoolVariable GFairyCantDestroy;
    public BoolVariable GFairyCantKill;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D fairyBody;
    private SpriteRenderer fairySprite;
    private float originalX;
    private float maxOffset;
    private float groundFairyPatrolTime;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxOffset = gameConstants.maxXOffset;
        groundFairyPatrolTime = gameConstants.groundFairyPatrolTime;
        fairyBody = this.GetComponent<Rigidbody2D>();
        fairySprite = this.GetComponent<SpriteRenderer>();
        fairySprite.flipX = moveRight < 0 ? true : false;
        originalX = this.transform.position.x;

        ComputeVelocity();
    }

    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / groundFairyPatrolTime, 0);
    }
    void MoveFairy()
    {
        fairyBody.MovePosition(fairyBody.position + velocity * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        // enemyAnimator.SetFloat("xSpeed", Mathf.Abs(fairyBody.velocity.x));
        if (Mathf.Abs(fairyBody.position.x - originalX) < maxOffset)
        {
            MoveFairy();
        }
        else
        {
            // change direction
            moveRight *= -1;
            fairySprite.flipX = !fairySprite.flipX;
            ComputeVelocity();
            MoveFairy();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            damagePlayer.Invoke();
        }
        else if (other.CompareTag("Hitbox"))
        {
            Debug.Log("Hit GFairy");
            if (!GFairyCantKill.Value)
            {
                Debug.Log("Kill GFairy");
                StartCoroutine(KillEnemy());
                enemyAnimator.SetTrigger("gotHit");
            }
        }
    }

    public override void OnMouseDown()
    {
        if (!GFairyCantDestroy.Value && destroyerMode.Value)
        {
            StartCoroutine(KillEnemy());
        }
    }
}
