using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    int roomNum = 0;
    public GameObject cam, selectedRoom, deathScreen, WinScreen;
    public GameObject[] roomPrefabs;

    const int roomHeight = 52;
    GameObject player; 
    float camHeight;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        deathScreen.SetActive(false);
        Cursor.visible = false;
        WinScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        camHeight = cam.transform.position.y;

        if (camHeight >= (roomNum * roomHeight) + 23 ) 
        {
            roomNum++;
            SpawnRoom();
        }

        // Player death sequence
        if (player.GetComponent<PlayerMovement>().health <= 0 || player == null)
        {
            GameObject.FindGameObjectWithTag("LifeDisplay").transform.GetChild(0).gameObject.SetActive(false);
            Destroy(player);
            deathScreen.SetActive(true);
            Time.timeScale = 0.1f;
            Cursor.visible = true;
        }

    }

    void SpawnRoom()
    {
        //For procedural, probably make two game object arrays, set second one to first on start, and whenever the second one gets randomly selected rooms spawned,
        //then removed from list, and when second list is all out of rooms, set second list to first again so it loops

        if (roomNum > roomPrefabs.Length)
        {
            //roomNum = 0;
        }
        //Select room from list of gameObjects then intantiate it at the current height
        //selectedRoom = roomPrefabs[roomNum];
        Instantiate(selectedRoom, new Vector3(0, roomNum * roomHeight, 0), Quaternion.identity);
        
    }


}
