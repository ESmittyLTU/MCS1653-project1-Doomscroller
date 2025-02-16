using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, heart4;
    int health;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerMovement>().health;

        if (health == 4)
        {
            heart4.SetActive(true);
        }
        else if (health == 3)
        {
            heart4.SetActive(false);
            heart3.SetActive(true);
        } 
        else if (health == 2) 
        { 
            heart3.SetActive(false);
            heart2.SetActive(true);
        } 
        else if (health == 1)
        {
            heart2.SetActive(false);
        }
        

    }
}
