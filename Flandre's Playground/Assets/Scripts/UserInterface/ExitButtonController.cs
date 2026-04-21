using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour
{
    public void ButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
