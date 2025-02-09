using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashDetection : MonoBehaviour
{

    public float squashJump = 5.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > transform.position.y + .9f)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * squashJump, ForceMode2D.Impulse);
            Destroy(transform.parent.gameObject);

        }
    }
}
