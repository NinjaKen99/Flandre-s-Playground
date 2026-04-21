using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Variables
    public RuleList ruleList;
    // Components
    public GameObject restartPanel;
    public GameObject gameOverPanel;
    public GameObject resetButton;
    public GameObject pauseButton;
    private AudioSource bgm;

    // Events
    public UnityEvent resume;

    // Start is called before the first frame update
    void Start()
    {
        // Hide all non-used UI
        restartPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        resetButton.SetActive(false);

        // Set all Rules true, All disabled
        ruleList.playermove.SetValue(true);
        ruleList.playerjump.SetValue(true);
        ruleList.playerattack.SetValue(true);
        ruleList.kedamaHit.SetValue(true);
        ruleList.kedamaDestroy.SetValue(true);
        ruleList.aFairyHit.SetValue(true);
        ruleList.aFairyDestroy.SetValue(true);
        ruleList.gFairyHit.SetValue(true);
        ruleList.gFairyDestroy.SetValue(true);

        // Get Components
        bgm = GetComponent<AudioSource>();
        resume.Invoke();
        bgm.Play();

        Time.timeScale = 1.0f;
    }

    // Pause and Resume
    public void OnPause()
    {
        restartPanel.SetActive(true);
        resetButton.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void OnResume()
    {
        restartPanel.SetActive(false);
        resetButton.SetActive(false);
        Time.timeScale = 1.0f;
    }

    // Game Over
    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
        resetButton.SetActive(true);
        pauseButton.SetActive(false);
        bgm.Stop();
        Time.timeScale = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
