using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Variables
    public GameConstants gameConstants;
    public BoolVariable destroyerMode;

    // Components
    private SpriteRenderer destroyCursor;
    private Animator cursorAnim;
    private AudioSource destroyAudio;

    // Start is called before the first frame update
    void Start()
    {
        destroyCursor = GetComponent<SpriteRenderer>();
        destroyAudio = GetComponent<AudioSource>();
        cursorAnim = GetComponent<Animator>();

        destroyCursor.enabled = false;
    }

    public void MoveCursor(Vector2 mousePosition)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
        // transform.position = Vector2.Lerp(transform.position, mousePosition, gameConstants.cursorSpeed);
    }

    // Show Cursor
    public void ActivateCursor()
    {
        destroyCursor.enabled = true;
    }

    // Hide Cursor
    public void DeactivateCursor()
    {
        destroyCursor.enabled = false;
    }

    // Mouse Click
    public void OnMouseClick()
    {
        if (destroyerMode.Value)
        {
            destroyAudio.PlayOneShot(destroyAudio.clip);
            cursorAnim.SetTrigger("clicked");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
