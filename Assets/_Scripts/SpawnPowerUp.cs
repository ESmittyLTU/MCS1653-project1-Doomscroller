using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject speed, jump, life, invinc;
    Vector3 here;
    void Start()
    {
        int selector = Random.Range(0, 10);
        here = transform.position;
        if (selector <= 3)
        {
            spawnPowerUp(jump);
        } else if (selector <= 6)
        {
            spawnPowerUp(speed);
        } else if (selector <= 8)
        {
            spawnPowerUp(life);
        } else if (selector == 9) 
        {
            spawnPowerUp(invinc);
        }


    }

    void spawnPowerUp(GameObject powerUp)
    {
        Instantiate(powerUp, here, Quaternion.identity);
        Destroy(gameObject);
    }
}
