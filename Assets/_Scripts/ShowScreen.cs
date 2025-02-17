using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScreen : MonoBehaviour
{
    public GameObject Screen;

    public void onClick()
    {
        Screen.SetActive(true);
        Cursor.visible = true;
    }
}
