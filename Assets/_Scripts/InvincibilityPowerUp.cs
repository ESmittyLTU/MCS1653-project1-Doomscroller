using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityPowerUp : MonoBehaviour
{
    GameObject invincIndicator;
    public GameObject collectEffect;
    public AudioClip collectSound;
    GameObject player;

    private void Start()
    {
        invincIndicator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioSource.PlayClipAtPoint(collectSound, cam.transform.position);
            Instantiate(collectEffect, transform.position, Quaternion.identity);

            player = other.gameObject;
            player.GetComponent<PlayerMovement>().invincTimer = player.GetComponent<PlayerMovement>().invincLength;
            player.GetComponent<PlayerMovement>().invincible = true;
            invincIndicator.SetActive(true);

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
