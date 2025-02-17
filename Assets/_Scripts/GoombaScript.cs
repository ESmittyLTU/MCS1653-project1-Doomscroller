using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GoombaScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.8f;
    public float tolerance = 0.05f;
    public GameObject deathEffect;

    private Vector3 currentTarget;
    private int nextTarget;

    private SpriteRenderer sr;
    private Animator anim;

    public AudioClip squashSound, playerHurt;
    private GameObject cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        currentTarget = waypoints[1].position;
        nextTarget = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enemy trigger entered");
        if (other.gameObject.CompareTag("Player")) { 
            if (other.gameObject.GetComponent<PlayerMovement>().invincible)
            {
                AudioSource.PlayClipAtPoint(squashSound, cam.transform.position);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                //Make another script, throw it on this gameobj, and call the function to run particle effects
                Destroy(gameObject);
            }
            else if (transform.GetChild(0).gameObject.GetComponent<SquashDetection>().squashed == false && transform.position.y + 0.75f >= other.transform.position.y)
            {
                other.gameObject.GetComponent<PlayerMovement>().health--;
                AudioSource.PlayClipAtPoint(playerHurt, cam.transform.position, 2f);
                Debug.Log("Health is " + other.gameObject.GetComponent<PlayerMovement>().health);
            }
        }

    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        if (Vector3.Distance(currentTarget, transform.position) < tolerance)
        {
            SwitchTargets();
        }
    }

    private void SwitchTargets()
    {
        currentTarget = waypoints[nextTarget].position;
        if (nextTarget == 0)
        {
            sr.flipX = true;
            nextTarget = 1;
        }
        else
        {
            sr.flipX = false;
            nextTarget = 0;
        }
    }
}

