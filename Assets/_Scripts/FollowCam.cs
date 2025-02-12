using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float trackSpeed = 5.0f;
    float storeTrackSpeed;
    float ultraSpeed = 100f;

    //public GameObject bg0;
    //public float bg0speed = 0.8f;


    public float scrollAmount = .01f;
    public float scrollAccel = 0.0001f;
    public float allowableOffset = 3.0f;
    
    private GameObject player;
    
    //minCamHeight public so later the dislikes scripts can grab it to determine height
    public float minCamHeight;

    // Improvements to consider:
    // - Easing movement at start and end
    // - Catching up more quickly if player is too far from center


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(0, 5, -10);
        minCamHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //for background
        //Vector3 oldPos = transform.position;

        // Auto scroll if camerapos is lower than mincamerapos
        if (transform.position.y < minCamHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y + scrollAmount, -10), scrollAmount * Time.deltaTime);
        }

        //Min cam height updates at the speed the camera would move at even if the player is above that position
        minCamHeight += scrollAmount * Time.deltaTime;
        scrollAmount += scrollAccel;

        //If the player is below the camera, and the camera isnt fast, store tracking speed, then set tracking speed to FAST
        if (player.transform.position.y < transform.position.y && trackSpeed != ultraSpeed)
        {
            storeTrackSpeed = trackSpeed;
            trackSpeed = ultraSpeed;
        }

        //If the camera is still moving fast, AND cam has caught up to the player (ie from a fall, then set the speed back to what it was)
        if (trackSpeed == ultraSpeed && Mathf.Abs(player.transform.position.y - transform.position.y) < allowableOffset)
        {
            trackSpeed = storeTrackSpeed;
        }

        // Track to player if difference between the player height and camera height exceeds the allowable offset
        if (Mathf.Abs(player.transform.position.y - transform.position.y) > allowableOffset)
        {
            if (player.transform.position.y > minCamHeight)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, player.transform.position.y, -10), trackSpeed * Time.deltaTime);
            }
            else // If player below minCamHeight, track to the minCam height position instead
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, minCamHeight, -10), trackSpeed * Time.deltaTime);
            }
        }

        //Vector3 newPos = transform.position;

        //Bacgkround pos
        //Vector3 delta = newPos - oldPos;
        //bg0.transform.position += new Vector3(delta.x, delta.y, 0) * bg0speed;





    }
}
