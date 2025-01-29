using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Declare vars
    public float speed, jump;


    // Mult variables for powerups later on
    float speedMult, jumpMult = 1.0f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputSpeed = Input.GetAxis("Horizontal");
        transform.position += inputSpeed * speedMult * new Vector3(1, 0, 0) * Time.deltaTime;
    }
}
