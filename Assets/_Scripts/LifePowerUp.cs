using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioSource.PlayClipAtPoint(collectSound, cam.transform.position);
            GameObject player = other.gameObject;

            Instantiate(collectEffect, transform.position, Quaternion.identity);
            
            if (player.GetComponent<PlayerMovement>().health < 4)
            {
                player.GetComponent<PlayerMovement>().health++;
            }
            Debug.Log("Health is " + player.GetComponent<PlayerMovement>().health);
            
            //Do all the effects
            Destroy(gameObject);
        }
    }
    public float amplitude = 0.001f;
    private void Update()
    {
        if (!PauseMenu.paused)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(Time.time) * amplitude), transform.position.z);
        }
    }
}
