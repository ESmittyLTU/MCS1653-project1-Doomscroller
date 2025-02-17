using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool paused;

    void Start()
    {
        pauseMenu.SetActive(false);
        paused = false;
    }
    void Update()
    {
        if (!paused && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESCAPED");
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            paused = true;
        }
        else if (paused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            paused = false;
        }
    }
}
