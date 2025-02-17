using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public AudioClip collectSound;
    public GameObject collectEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGERED");
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioSource.PlayClipAtPoint(collectSound, cam.transform.position);
            Instantiate(collectEffect, transform.position, Quaternion.identity);
            GameObject player = other.gameObject;
            player.GetComponent<PlayerMovement>().speedMult += 0.125f;
            Debug.Log("SpeedMult is" + player.GetComponent<PlayerMovement>().speedMult);
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
