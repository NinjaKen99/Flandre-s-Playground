using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFairyController : EnemyController
{
    // Added Variables
    public BoolVariable AFairyCantDestroy;
    public BoolVariable AFairyCantKill;
    private int moveUp = -1;
    private Vector2 velocity;
    private Rigidbody2D fairyBody;
    private float originalY;
    private float maxOffset;
    private float airFairyPatrolTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxOffset = gameConstants.maxYOffset;
        airFairyPatrolTime = gameConstants.airFairyPatrolTime;
        fairyBody = this.GetComponent<Rigidbody2D>();
        originalY = this.transform.position.y;

        ComputeVelocity();
    }

    void ComputeVelocity()
    {
        velocity = new Vector2(0, (moveUp) * maxOffset / airFairyPatrolTime);
    }
    void MoveFairy()
    {
        fairyBody.MovePosition(fairyBody.position + velocity * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(fairyBody.position.y - originalY) < maxOffset)
        {// move goomba
            MoveFairy();
        }
        else
        {
            // change direction
            moveUp *= -1;
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
            Debug.Log("Hit AFairy");
            if (!AFairyCantKill.Value)
            {
                Debug.Log("Kill AFairy");
                StartCoroutine(KillEnemy());
                enemyAnimator.SetTrigger("gotHit");
            }
        }
    }

    public override void OnMouseDown()
    {
        if (!AFairyCantDestroy.Value && destroyerMode.Value)
        {
            StartCoroutine(KillEnemy());
        }
    }
}
