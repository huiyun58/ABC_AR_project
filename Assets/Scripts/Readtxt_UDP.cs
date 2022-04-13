using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

// read the UDP messages from the UDP client, and put them into respective variables
public class Readtxt_UDP : MonoBehaviour
{
    public float time;
    public float volume;
    public int valve_status;
    public int patient_switch;
    public float threshold;
    public int total_countdowntime;
    public int teleop_msg;
    string s;
    string[] sArray;

    // UDP
    private UDPClient client;

    void Start()
    {
        client = GetComponent<UDPClient>();
        
    }

    void FixedUpdate()
    {
        // UDP
        s = client.GetLatestUDPPacket();
        if (s != "")
        {
            
            // Use a comma to separate the Data
            sArray = s.Split(',');
            if (sArray[0] != "nan")
            {

                time = float.Parse(sArray[0]);
                volume = float.Parse(sArray[1]);
                if (volume < 0)
                {
                    volume = 0;
                }
                valve_status = int.Parse(sArray[2]);
                patient_switch = int.Parse(sArray[3]);
                threshold = float.Parse(sArray[4]);
                total_countdowntime = int.Parse(sArray[5]);
                teleop_msg = int.Parse(sArray[6]);
            }
        }

    }

}

