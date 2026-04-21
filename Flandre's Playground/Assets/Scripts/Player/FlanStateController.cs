using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FlanStateController : StateController
{
    // Components
    public GameConstants gameConstants;
    public BoolVariable destroyerMode;
    public BoolVariable cantAttack;
    public AudioClip attack;
    private SpriteRenderer spriteRenderer;

    // Events
    public UnityEvent showCursor;
    public UnityEvent hideCursor;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        GameRestart();
    }

    public void GameRestart()
    {
        destroyerMode.SetValue(false);
        TransitionToState(startState);
    }

    public void Attack()
    {
        if (!cantAttack.Value)
        {
            this.currentState.DoEventTriggeredActions(this, ActionType.Attack);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(attack);
        }
    }

    public void StateChange()
    {
        destroyerMode.Toggle();
        if (destroyerMode.Value)
        {
            showCursor.Invoke();
        }
        else
        {
            hideCursor.Invoke();
        }
    }

    // public void SetRendererToFlicker()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    //     StartCoroutine(BlinkSpriteRenderer());
    // }
    // private IEnumerator BlinkSpriteRenderer()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    //     while (string.Equals(currentState.name, "DeadFlandre", System.StringComparison.OrdinalIgnoreCase))
    //     {
    //         // Toggle the visibility of the sprite renderer
    //         spriteRenderer.enabled = !spriteRenderer.enabled;

    //         // Wait for the specified blink interval
    //         yield return new WaitForSeconds(gameConstants.flickerInterval);
    //     }

    //     spriteRenderer.enabled = true;
    // }
}
