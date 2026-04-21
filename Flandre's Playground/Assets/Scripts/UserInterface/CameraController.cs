using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform endLimit; // GameObject that indicates end of map
    public Transform endLimit2; // GameObject that indicates end of map
    public Transform player; // Player GameObject found in script
    private float xOffset; // initial x-offset between camera and Player
    private float yOffset; // y-offset between camera and Player
    private float startX; // smallest x-coordinate of the Camera
    private float endX; // largest x-coordinate of the camera
    private float startY; // smallest y-coordinate of the Camera
    private float endY; // largest y-coordinate of the camera
    private float viewportHalfWidth;
    private float viewportHalfHeight;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // get coordinate of the bottomleft of the viewport
        // z doesn't matter since the camera is orthographic
        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)); // the z-component is the distance of the resulting plane from the camera 
        viewportHalfWidth = Mathf.Abs(bottomLeft.x - this.transform.position.x);
        viewportHalfHeight = Mathf.Abs(bottomLeft.y - this.transform.position.y);
        xOffset = this.transform.position.x - player.position.x;
        xOffset = this.transform.position.y - player.position.y;
        startX = this.transform.position.x;
        startY = this.transform.position.y;
        endX = endLimit.transform.position.x - viewportHalfWidth;
        endY = endLimit2.transform.position.y - viewportHalfHeight;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float desiredX = player.position.x + xOffset;
        float desiredY = player.position.y + yOffset;
        // check if desiredX is within startX and endX, maybe adjust to 
        if (desiredX > startX && desiredX < endX)
        {
            this.transform.position = new Vector3(desiredX, this.transform.position.y, this.transform.position.z);
        }
        if (desiredY > startY && desiredY < endY)
        {
            this.transform.position = new Vector3(this.transform.position.x, desiredY, this.transform.position.z);
        }
    }
    public void GameRestart()
    {
        transform.position = startPosition;
    }
    public void PauseAudio()
    {
        AudioListener.pause = true;
    }
    public void ResumeAudio()
    {
        AudioListener.pause = false;
    }
}
