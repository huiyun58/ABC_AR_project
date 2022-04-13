using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// allow user to play specific music clip when calling this function
public class Sound_Handler : MonoBehaviour
{

    public AudioSource clip1;
    public AudioSource clip2;
    public AudioSource clip3;
    public AudioSource clip4;
    public AudioSource clip5;
    public AudioSource clip6;


    public void PlayClip(int paragraph_number)
    {
        if (paragraph_number == 1)
        {
            clip1.Play(); // breath in
        }
        else if (paragraph_number == 2)
        {
            clip2.Play(); // breath out
        }
        else if (paragraph_number == 3)
        {
            clip3.Play();  // take a deep breath in
        }
        else if (paragraph_number == 4)
        {
            clip4.Play(); // hold your breath
        }
        else if (paragraph_number == 5)
        {
            clip5.Play(); // 5 sec left
        }
        else if (paragraph_number == 6)
        {
            clip6.Play();  // great job
        }
    }

}
