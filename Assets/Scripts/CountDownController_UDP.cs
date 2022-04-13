using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

// count down when patient_switch is on and dataclass.volume is larger than dataclass.threshold.
// Show the count down number on the top of the graph

public class CountDownController_UDP : MonoBehaviour
{
    public int countdownTime;
    private int countdownTime_tot;
    public Text countdownDisplay;

    int i = 0;

    Readtxt_UDP dataclass;


    void Start()
    {
        dataclass = this.GetComponent<Readtxt_UDP>();

        countdownTime = 0;
        countdownTime_tot = 0;
    }

    void FixedUpdate()
    {

        if (countdownTime_tot != dataclass.total_countdowntime)
        {
            countdownTime = dataclass.total_countdowntime;
            countdownTime_tot = dataclass.total_countdowntime;
        }


        if (dataclass.patient_switch == 1 & dataclass.volume > dataclass.threshold)
        {
            // update the countdownDisplay every second
            // since the update rate is 0.02 sec, 50 * 0.02 = 1 sec
            if (i % 50 == 0 & countdownTime >= 0)
            {
                countdownDisplay.gameObject.SetActive(true);
                countdownDisplay.text = countdownTime.ToString();
                countdownTime--;
            }

            i += 1;
        }
        else
        {
            countdownDisplay.gameObject.SetActive(false);
            countdownTime = countdownTime_tot;
            i = 0;
        }
    }


}


