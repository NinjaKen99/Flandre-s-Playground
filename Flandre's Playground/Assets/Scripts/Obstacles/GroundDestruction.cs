using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestruction : MonoBehaviour, DestructibleController
{
    // Variables
    public BoolVariable destroyerMode;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (destroyerMode.Value)
        {
            Destroy(this.gameObject);
        }
    }
}
