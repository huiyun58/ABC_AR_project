using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allow user to rotate and adjust pitch of the graph by pressing "wasd" on the keyboard
public class Teleop_window : MonoBehaviour
{

    private int teleop_msg;

    private Transform GHRenderer;
    private RectTransform CanvasRenderer;
    private Transform ButtonRenderer;

    Readtxt_UDP dataclass;

    // Start is called before the first frame update
    void Start()
    {
        GHRenderer = GetComponent<Transform>();
        CanvasRenderer = GameObject.Find("Canvas").GetComponent<RectTransform>();
        ButtonRenderer = GameObject.Find("ButtonContainer").GetComponent<Transform>();
        dataclass = this.GetComponent<Readtxt_UDP>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (dataclass.teleop_msg != 0)
        {
            // "w" = up
            if (dataclass.teleop_msg == 1)
            {
                GHRenderer.Rotate(new Vector3(-.5f, 0, 0));
                ButtonRenderer.Rotate(new Vector3(-.5f, 0, 0));
            }
            // "s" = down
            else if (dataclass.teleop_msg == 2)
            {
                GHRenderer.Rotate(new Vector3(.5f, 0, 0));
                ButtonRenderer.Rotate(new Vector3(.5f, 0, 0));
            }
            // "a" = rotate ccw
            else if (dataclass.teleop_msg == 3)
            {
                CanvasRenderer.Rotate(new Vector3(0, 0, .5f));
                ButtonRenderer.Rotate(new Vector3(0, 0, .5f));
            }
            // "d" = rotate cw
            else if (dataclass.teleop_msg == 4)
            {
                CanvasRenderer.Rotate(new Vector3(0, 0, -.5f));
                ButtonRenderer.Rotate(new Vector3(0, 0, -.5f));
            }
        }
    }
}
