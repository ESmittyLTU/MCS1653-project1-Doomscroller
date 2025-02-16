using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerMovement>().jumpMult += 0.07f;
            Debug.Log("JumpMult is" + player.GetComponent<PlayerMovement>().jumpMult);
            //Do all the effects
            Destroy(gameObject);
        }
    }
}
