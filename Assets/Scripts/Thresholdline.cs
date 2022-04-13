using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

// draw the threshold line onto the graph based on the realtime UDP message
public class Thresholdline : MonoBehaviour
{
    GameObject handler;
    Readtxt_UDP dataclass;

    private float threshold;

    void Start()
    {
        handler = GameObject.Find("GameHandler");
        dataclass = handler.GetComponent<Readtxt_UDP>();
    }

    void Update()
    {
        
        threshold = dataclass.threshold;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, (threshold - 3f) / 3f * 200f);
    }
}

