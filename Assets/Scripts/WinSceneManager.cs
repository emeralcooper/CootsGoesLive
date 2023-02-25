using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneManager : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
