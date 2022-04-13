using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// necessary to remove unwanted error consoles
public class Remove_console : MonoBehaviour
{

    void Update()
    {
        Debug.developerConsoleVisible = false;
    }
}
