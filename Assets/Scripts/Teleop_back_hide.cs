using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// allow user to go back to main menu or hide the side buttons on the graph by pressing "b" or "h" on the keyboard
public class Teleop_back_hide : MonoBehaviour
{

    Readtxt_UDP dataclass;
    Hide_back hideback;

    // Start is called before the first frame update
    void Start()
    {
        dataclass = GetComponent<Readtxt_UDP>();
        hideback = GameObject.Find("ButtonContainer").GetComponent<Hide_back>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dataclass.teleop_msg != 0)
        {
            // "b" = back
            if (dataclass.teleop_msg == 6)
            {
                SceneManager.LoadScene(0);
            }
            // "h" = hide
            else if (dataclass.teleop_msg == 7)
            {
                hideback.hidebutton();
                // sleep for 0.2 sec
                System.Threading.Thread.Sleep(200);
            }
        }

    }
}
