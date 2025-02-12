using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int roomNum = 0;
    public GameObject cam, selectedRoom;
    public GameObject[] roomPrefabs;

    const int roomHeight = 52;

    float camHeight;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
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
