using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashDetection : MonoBehaviour
{
    public GameObject deathEffect;
    public float squashJump = 5.0f;
    public bool squashed = false;

    public AudioClip squashSound;
    private GameObject cam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y + .5f && other.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            cam = GameObject.FindGameObjectWithTag("MainCamera");
            AudioSource.PlayClipAtPoint(squashSound, cam.transform.position);
            squashed = true;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
            rb.AddForce(Vector3.up * squashJump, ForceMode2D.Impulse);
            Destroy(transform.parent.gameObject);

        }
    }
}
