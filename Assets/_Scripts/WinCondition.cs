using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject WinScreen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0.1f;
            Cursor.visible = true;
            Destroy(other.gameObject);
        }
    }
}
