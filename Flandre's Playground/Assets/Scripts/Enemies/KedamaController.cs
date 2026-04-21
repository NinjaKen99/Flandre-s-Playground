using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KedamaController : MonoBehaviour, DestructibleController
{
    ////// The Kedama is going to be a stationary enemy that damages on contact
    // Variables
    private Vector3 localStartPosition;
    public BoolVariable kedamaCantDestroy;
    public BoolVariable kedamaCantKill;
    public BoolVariable destroyerMode;

    //Components


    // Events
    public UnityEvent damagePlayer;

    void Awake()
    {
        localStartPosition = this.transform.localPosition;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Check for contact
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            damagePlayer.Invoke();
        }
        else if (other.CompareTag("Hitbox"))
        {
            Debug.Log("Hit Kedama");
            if (!kedamaCantKill.Value)
            {
                Debug.Log("Kill Kedama");
                Destroy(this.gameObject);
            }
        }
    }

    // Destroy
    public void OnMouseDown()
    {
        if (!kedamaCantDestroy.Value && destroyerMode.Value) Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
