using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : MonoBehaviour
{
    GameObject invincIndicator;
    
    GameObject player;

    private void Start()
    {
        invincIndicator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.GetComponent<PlayerMovement>().invincTimer = player.GetComponent<PlayerMovement>().invincLength;
            player.GetComponent<PlayerMovement>().invincible = true;
            invincIndicator.SetActive(true);

            Destroy(gameObject);
        }
    }
}
