using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


// count down when patient_switch is on and dataclass.volume is larger than dataclass.threshold.
// Show the count down number on the top of the graph

public class CountDownController_mode2 : MonoBehaviour
{
    public int countdownTime;

    public int countupTime;
    private int countdownTime_tot;
    public Text countdownDisplay;
    public Text TextDisplay;

    int i = 0;
    private float threshold;

    private Sound_Handler sh;

    Readtxt_UDP dataclass;

    // Start is called before the first frame update
    void Start()
    {
        sh = GameObject.Find("GameHandler").GetComponent<Sound_Handler>();
        dataclass = this.GetComponent<Readtxt_UDP>();
        threshold = dataclass.threshold;
        countdownTime = 0;
        countdownTime_tot = 0;
    }

    void FixedUpdate()
    {
        threshold = dataclass.threshold;
        
        if (countdownTime_tot != dataclass.total_countdowntime)
        {
            countdownTime = dataclass.total_countdowntime;
            countdownTime_tot = dataclass.total_countdowntime;
        }

        if (dataclass.patient_switch == 1 & dataclass.volume > threshold)
        {
            // update the countdownDisplay every second
            // since the update rate is 0.02 sec, 50 * 0.02 = 1 sec
            if ((i % 50) == 0 & countdownTime >= 0)
            {
                countdownDisplay.gameObject.SetActive(true);
                countdownDisplay.text = countdownTime.ToString();


                // "please hold your breath"
                if (countdownTime > 5 & countdownTime <= countdownTime_tot)
                {
                    TextDisplay.text = paragraph(4);
                    if (countdownTime == countdownTime_tot)
                    {
                        sh.PlayClip(4);
                    }
                }
                // "please hold your breath \n five seconds left"
                else if (countdownTime <= 5 & countdownTime > 0)
                {
                    TextDisplay.text = paragraph(5); // 5 sec left
                    if (countdownTime == 5)
                    {
                        sh.PlayClip(5);
                    }
                }
                // "Great job!"
                else if (countdownTime == 0)
                {
                    TextDisplay.text = paragraph(6); // great job
                    sh.PlayClip(6);
                }
                // "  "
                else
                {
                    TextDisplay.text = paragraph(0);
                }

                countdownTime--;

            }

            i += 1;
        }
        else
        {
            countdownDisplay.gameObject.SetActive(false);
            TextDisplay.text = paragraph(0);
            countdownTime = countdownTime_tot;
            i = 0;
        }
    }

    public string paragraph(int clip_number)
    {
        if (clip_number == 1)
        {
            return "breath in";
        }
        else if (clip_number == 2)
        {
            return "breath out";
        }
        else if (clip_number == 3)
        {
            return "take a deep breath in";
        }
        else if (clip_number == 4)
        {
            return "please hold your breath";
        }
        else if (clip_number == 5)
        {
            return "please hold your breath \n five seconds left";
        }
        else if (clip_number == 6)
        {
            return "Great job!";
        }
        else
        {
            return "  ";
        }

    }


}
