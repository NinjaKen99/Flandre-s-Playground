using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GoToLevel()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }
}
