using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingDislikes : MonoBehaviour
{
    float minHeight;
    private GameObject cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerMovement>().invincible)
            {
                //Do nothing
            } else
            {
                Destroy(other.gameObject);
            }
        }
    }

    void Update()
    {
        minHeight = cam.GetComponent<FollowCam>().minCamHeight;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, minHeight - 8, -3), minHeight * Time.deltaTime);
    }
}
