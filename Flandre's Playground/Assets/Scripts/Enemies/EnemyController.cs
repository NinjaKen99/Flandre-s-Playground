using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EnemyController : MonoBehaviour
{
    // Variables
    public GameConstants gameConstants;
    public BoolVariable destroyerMode;
    protected Vector3 startPosition;

    // Components
    protected Animator enemyAnimator;

    // Events
    public UnityEvent damagePlayer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void OnTriggerEnter2D(Collider2D other);

    public abstract void OnMouseDown();

    protected IEnumerator KillEnemy()
    {
        yield return new WaitForSeconds(gameConstants.disappearDelay);
        Destroy(this.gameObject);
    }
}
