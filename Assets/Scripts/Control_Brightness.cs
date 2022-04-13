using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.UI;
using System;

// the script is not in use right now.
// allow users to control background brightness by slider
public class Control_Brightness : MonoBehaviour
{
    

    private int val;
    private byte val_byte;


    public void SetBrightness(SliderEventData eventData)
    {

        val = Convert.ToInt32(eventData.NewValue * 200);
        val_byte = Convert.ToByte(val);
        this.GetComponent<Image>().color = new Color32(val_byte, val_byte, val_byte, 255);
    }
}
