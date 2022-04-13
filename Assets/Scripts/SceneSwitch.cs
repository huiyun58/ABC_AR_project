using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// allow user to enter the next scene or exit the app when calling these functions
public class SceneSwitch : MonoBehaviour
{
    public void gotoMode1()
    {
        SceneManager.LoadScene(1);
    }
    public void gotoMode2()
    {
        SceneManager.LoadScene(2);
    }
    public void backtoStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void exitapp()
    {
        Application.Quit();
    }
}