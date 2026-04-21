using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    // Variables
    private float localPositionX;
    private float localPositionY;
    private float localPositionZ;

    // Components
    private BoxCollider2D hitbox;
    private AudioSource impactAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Set private references
        hitbox = GetComponent<BoxCollider2D>();
        impactAudio = GetComponent<AudioSource>();
    }

    // Switch Hitbox Side
    public void SwitchSides()
    {
        Debug.Log("Switch");
        localPositionX = transform.localPosition.x;
        localPositionY = transform.localPosition.y;
        localPositionZ = transform.localPosition.z;
        this.transform.localPosition = new Vector3(localPositionX * -1, localPositionY, localPositionZ);
    }

    // Enable Collider
    public void EnableCollider()
    {
        hitbox.enabled = true;
    }

    // Disable Collider
    public void DisableCollider()
    {
        hitbox.enabled = false;
    }

    // When attack hits collider
    void OnCollisionEnter2D(Collision2D col)
    {
        // Play impact Audio
        impactAudio.PlayOneShot(impactAudio.clip);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
