using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

// allow user to adjust pitch of the graph when calling these functions
public class Adjust_pitch : MonoBehaviour
{
    
    private Transform TargetRenderer;
    private Transform ButtonRenderer;

    void Start()
    {

        TargetRenderer = GetComponent<Transform>();
        ButtonRenderer = GameObject.Find("ButtonContainer").GetComponent<Transform>();
    }

    public void MoveUp()
    {

        TargetRenderer.Rotate(new Vector3(-3f, 0, 0));
        ButtonRenderer.Rotate(new Vector3(-3f, 0, 0));

    }

    public void MoveDown()
    {

        TargetRenderer.Rotate(new Vector3(+3f, 0,0));
        ButtonRenderer.Rotate(new Vector3(+3f, 0,0));

    }
}

