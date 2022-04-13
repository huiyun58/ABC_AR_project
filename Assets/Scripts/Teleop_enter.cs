using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// allow user to enter mode 1 or 2 by pressing "e" on the keyboard
public class Teleop_enter : MonoBehaviour
{

    Readtxt_UDP dataclass;

    // Start is called before the first frame update
    void Start()
    {
        dataclass = GetComponent<Readtxt_UDP>();
    }

    // Update is called once per frame
    void Update()
    {
        // "e" = enter
        if (dataclass.teleop_msg == 5)
        {
            SceneManager.LoadScene(1);
        }
    }
}