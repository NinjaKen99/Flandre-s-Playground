using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathZoneController : MonoBehaviour
{
    public UnityEvent playerdeath;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerdeath.Invoke();
    }
}
