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
    void Update()
    {
        minHeight = cam.GetComponent<FollowCam>().minCamHeight;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, minHeight - 8, -10), minHeight * Time.deltaTime);
    }
}
