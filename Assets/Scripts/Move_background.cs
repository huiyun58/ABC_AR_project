using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// slowly move the background to the left when the bird is flying
public class Move_background : MonoBehaviour
{
    GameObject background;
    GameObject background_left;
    GameObject background_right;

    GameObject handler;
    Readtxt_UDP dataclass;

    void Start()
    {
        // two black shield the covered on top of the left and right background, so the user will only see the picture between the two black shield
        // black is transparent on the headset
        background = GameObject.Find("graph_background");
        background_left = GameObject.Find("graph_background_left");
        background_right = GameObject.Find("graph_background_right");
        handler = GameObject.Find("GameHandler");
        dataclass = handler.GetComponent<Readtxt_UDP>();
    }

    void Update()
    {
        
        if (dataclass.patient_switch == 1) {

            if (background.GetComponent<RectTransform>().localPosition.x > -600){

                background.GetComponent<RectTransform>().localPosition += new Vector3(-0.1f, 0, 0);
                background_left.GetComponent<RectTransform>().localPosition += new Vector3(-0.1f, 0, 0);
                background_right.GetComponent<RectTransform>().localPosition += new Vector3(-0.1f, 0, 0);
            }

            else {

                background_left.GetComponent<RectTransform>().localPosition = background.GetComponent<RectTransform>().localPosition;
                background.GetComponent<RectTransform>().localPosition = background_right.GetComponent<RectTransform>().localPosition;
                background_right.GetComponent<RectTransform>().localPosition += new Vector3(1200f, 0, 0);
            }

        }

    }
}
