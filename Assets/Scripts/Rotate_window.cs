using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

// allow user to rotate the angle of the graph when calling these functions
public class Rotate_window : MonoBehaviour
{
    private RectTransform TargetRenderer;
    private Transform ButtonRenderer;

    void Start() {
        
        TargetRenderer = GetComponent<RectTransform>();
        ButtonRenderer = GameObject.Find("ButtonContainer").GetComponent<Transform>();
    }

    public void CWRotate()
    {

        TargetRenderer.Rotate(new Vector3(0, 0, -3f));
        ButtonRenderer.Rotate(new Vector3(0, 0, -3f));

    }

    public void CCWRotate()
    {

        TargetRenderer.Rotate(new Vector3(0, 0, +3f));
        ButtonRenderer.Rotate(new Vector3(0, 0, +3f));

    }

}

