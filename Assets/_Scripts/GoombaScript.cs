using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GoombaScript : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.8f;
    public float tolerance = 0.05f;
    
    private Vector3 currentTarget;
    private int nextTarget;

    void Start()
    {
        currentTarget = waypoints[1].position;
        nextTarget = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enemy trigger entered");

        if (other.gameObject.CompareTag("Player") && other.transform.position.y < transform.position.y + .9f)
        {
            other.gameObject.GetComponent<PlayerMovement>().health--;
            Debug.Log("Health is " + other.gameObject.GetComponent<PlayerMovement>().health);

            if (other.gameObject.GetComponent<PlayerMovement>().health <= 0)
            {
                Destroy(other.gameObject);
            }
        }

    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget,
speed * Time.deltaTime);
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
            nextTarget = 1;
        }
        else
        {
            nextTarget = 0;
        }
    }
}

