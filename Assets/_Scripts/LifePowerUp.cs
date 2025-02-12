using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            if (player.GetComponent<PlayerMovement>().health >= 3)
            {
                player.GetComponent<PlayerMovement>().health++;
            }
            Debug.Log("Health is " + player.GetComponent<PlayerMovement>().health);
            
            //Do all the effects
            Destroy(gameObject);
        }
    }
}
