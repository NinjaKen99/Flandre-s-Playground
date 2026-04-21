using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ActionManager : MonoBehaviour
{
    // Components
    public FlanActions flanActions;
    public PlayerInput playerinput;

    // Events
    public UnityEvent<int> moveCheck;
    public UnityEvent<Vector2> cursorMovement;
    public UnityEvent attack;
    public UnityEvent stateChange;
    public UnityEvent click;
    // public UnityEvent attack;

    // Start is called before the first frame update
    void Start()
    {
        flanActions = new FlanActions();
        flanActions.gameplay.Enable();
    }

    public void GameOver()
    {
        flanActions.gameplay.Disable();
    }

    // called twice, when pressed and unpressed
    public void OnMoveAction(InputAction.CallbackContext context)
    {
        // Debug.Log("OnMoveAction callback invoked");
        if (context.started)
        {
            Debug.Log("move started");
            int faceRight = context.ReadValue<float>() > 0 ? 1 : -1;
            moveCheck.Invoke(faceRight);
        }
        if (context.canceled)
        {
            Debug.Log("move stopped");
            moveCheck.Invoke(0);
        }
    }
    // Movement checks
    public void OnAttackAction(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Fire was started");
        else if (context.performed)
        {
            attack.Invoke();
            Debug.Log("Fire was performed");
        }
        else if (context.canceled)
            Debug.Log("Fire was cancelled");
    }

    public void OnStateChangeAction(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Change was started");
        else if (context.performed)
        {
            stateChange.Invoke();
            Debug.Log("Change was performed");
        }
        else if (context.canceled)
            Debug.Log("Change was cancelled");
    }

    public void OnPointAction(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Point was started");
        else if (context.performed)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            cursorMovement.Invoke(mousePosition);
            Debug.Log("Point was performed");
        }
        else if (context.canceled)
            Debug.Log("Point was cancelled");
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("Point was started");
        else if (context.performed)
        {
            click.Invoke();
            Debug.Log("Point was performed");
        }
        else if (context.canceled)
            Debug.Log("Point was cancelled");
    }
}