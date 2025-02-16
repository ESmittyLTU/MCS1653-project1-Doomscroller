using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerMovement>().speedMult += 0.15f;
            Debug.Log("SpeedMult is" + player.GetComponent<PlayerMovement>().speedMult);
            //Do all the effects
            Destroy(gameObject);
        }
    }
}
