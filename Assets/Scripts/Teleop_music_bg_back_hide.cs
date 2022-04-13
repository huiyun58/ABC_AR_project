using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// allow user to turn on/off music by  pressing "m";
// change background by pressing "c";
// go back to main menu by pressing "b";
// hide the side buttons on the graph by pressing "h" on the keyboard.
public class Teleop_music_bg_back_hide : MonoBehaviour
{

    Readtxt_UDP dataclass;
    Hide_button hidebutton;
    BGSwitch bgswitch;
    MusicSwitch musicswitch;

    private int curr_bg_num;

    void Start()
    {
        dataclass = GetComponent<Readtxt_UDP>();
        hidebutton = GameObject.Find("ButtonContainer").GetComponent<Hide_button>();
        bgswitch = GameObject.Find("ButtonContainer").GetComponent<BGSwitch>();
        musicswitch = GameObject.Find("ButtonContainer").GetComponent<MusicSwitch>();

        curr_bg_num = 1;
    }

    void Update()
    {
        if (dataclass.teleop_msg != 0)
        {
            if (dataclass.teleop_msg == 6)// "b" = back
            {
                SceneManager.LoadScene(0);
            }
            else if (dataclass.teleop_msg == 7)// "h" = hide
            {
                hidebutton.hidebutton();
                // sleep for 0.2 sec
                System.Threading.Thread.Sleep(200);
            }
            else if (dataclass.teleop_msg == 8)// "c" = change background
            {
                if (curr_bg_num == 1)
                {
                    bgswitch.beach();
                }
                else if (curr_bg_num == 2)
                {
                    bgswitch.nightsky();
                }
                else if (curr_bg_num == 3)
                {
                    bgswitch.meadow();
                    curr_bg_num -= 3;
                }
                curr_bg_num += 1;
                
                System.Threading.Thread.Sleep(200);


            }
            else if (dataclass.teleop_msg == 9)// "m" = music
            {
                musicswitch.music_on_off();
                // sleep for 0.2 sec
                System.Threading.Thread.Sleep(200);
            }
        }

    }
}