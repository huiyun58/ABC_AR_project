using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


// allow user to hide and unhide side buttons in mode 1 when calling these functions
public class Hide_back : MonoBehaviour
{
    
    public GameObject cw_button;
    public GameObject ccw_button;
    public GameObject up_button;
    public GameObject down_button;
    GameObject status_text;
    TextMeshPro statusDisplay;

    public void hidebutton()
    {
        
        status_text = GameObject.Find("status_text");

        statusDisplay = status_text.GetComponent<TextMeshPro>();


        if (cw_button.activeSelf == true)
        {
            
            cw_button.SetActive(false);
            ccw_button.SetActive(false);
            up_button.SetActive(false);
            down_button.SetActive(false);
            statusDisplay.text = "Show";
        }
        else
        {

            
            cw_button.SetActive(true);
            ccw_button.SetActive(true);
            up_button.SetActive(true);
            down_button.SetActive(true);
            statusDisplay.text = "Hide";

        }
    }
}
