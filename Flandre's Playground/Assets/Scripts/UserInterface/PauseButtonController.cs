using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PauseButtonController : MonoBehaviour, IInteractiveButton
{
    // Variables
    private bool isPaused = false;

    // Components
    public Sprite pauseIcon;
    public Sprite playIcon;
    private Image image;

    // Events
    public UnityEvent gamePaused;
    public UnityEvent gameResumed;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ButtonClick()
    {
        // Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        // state.paused = isPaused;
        if (isPaused)
        {
            image.sprite = playIcon;
            gamePaused.Invoke();
        }
        else
        {
            image.sprite = pauseIcon;
            gameResumed.Invoke();
        }
    }
}
