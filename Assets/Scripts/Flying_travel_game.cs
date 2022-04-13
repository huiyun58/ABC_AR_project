using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

// control the animation of the flying bird
public class Flying_travel_game : MonoBehaviour
{
    private GameObject blueJay;
    private Vector3 blueJay_home_pos;
    Animator bird_Animator;
    int interpolationFramesCount = 1000; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    float interpolationRatio;
    Vector2 interpolatedPosition;
    Vector2 target;

    private GameObject window_graph;
    private float target_x;
    private float target_y;
    private bool bird_is_out = false;

    Readtxt_UDP dataclass;


    void Start()
    {
        dataclass = this.GetComponent<Readtxt_UDP>();
        blueJay = GameObject.Find("blueJay");
        bird_Animator = blueJay.GetComponent<Animator>();
        blueJay_home_pos = blueJay.GetComponent<RectTransform>().anchoredPosition;
        window_graph = GameObject.Find("Window_Graph");
    }

    
    void FixedUpdate()
    {
        // bird start flying when patient_switch button is pressed
        if (dataclass.patient_switch == 1)
        {
            // target position is the position of the latest updating data point on the graph
            target_x = window_graph.GetComponent<Window_Graph_UDP>().xPosition - 800f / 2;
            target_y = window_graph.GetComponent<Window_Graph_UDP>().yPosition - 400f / 2 - 50;


            bird_Animator.SetBool("is_flying", true);


            // add motion interpolation
            target = new Vector2(target_x, target_y);
            float xdiff = Math.Abs(target_x - blueJay.GetComponent<RectTransform>().anchoredPosition.x);
            float ydiff = Math.Abs(target_y - blueJay.GetComponent<RectTransform>().anchoredPosition.y);

            // move by steps if the target is still far away
            if (xdiff > 1f | ydiff > 10f)
            {
                interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
                interpolatedPosition = Vector2.Lerp(blueJay.GetComponent<RectTransform>().anchoredPosition, target, interpolationRatio);
                blueJay.GetComponent<RectTransform>().anchoredPosition = blueJay.GetComponent<RectTransform>().anchoredPosition + new Vector2(interpolatedPosition.x - blueJay.GetComponent<RectTransform>().anchoredPosition.x, interpolatedPosition.y - blueJay.GetComponent<RectTransform>().anchoredPosition.y);
                elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
            }
            // directly put the bird onto the target if they're close enough
            else
            {
                blueJay.GetComponent<RectTransform>().anchoredPosition = blueJay.GetComponent<RectTransform>().anchoredPosition + new Vector2(target.x - blueJay.GetComponent<RectTransform>().anchoredPosition.x, target.y - blueJay.GetComponent<RectTransform>().anchoredPosition.y);
            }

            bird_is_out = true;
        }
        // bird fly back to its original position when the button is released
        else
        {
            bird_Animator.SetBool("is_flying", false);

            target = blueJay_home_pos;


            if (bird_is_out == true)
            {

                if (target.x < blueJay.GetComponent<RectTransform>().anchoredPosition.x)
                {
                    float xdiff = Math.Abs(target.x - blueJay.GetComponent<RectTransform>().anchoredPosition.x);
                    if (xdiff > 1f)
                    {
                        interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
                        interpolatedPosition = Vector2.Lerp(blueJay.GetComponent<RectTransform>().anchoredPosition, target, interpolationRatio);
                        blueJay.GetComponent<RectTransform>().anchoredPosition = blueJay.GetComponent<RectTransform>().anchoredPosition + new Vector2(interpolatedPosition.x - blueJay.GetComponent<RectTransform>().anchoredPosition.x, interpolatedPosition.y - blueJay.GetComponent<RectTransform>().anchoredPosition.y);
                        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
                    }
                    else
                    {
                        blueJay.GetComponent<RectTransform>().anchoredPosition = blueJay.GetComponent<RectTransform>().anchoredPosition + new Vector2(target.x - blueJay.GetComponent<RectTransform>().anchoredPosition.x, target.y - blueJay.GetComponent<RectTransform>().anchoredPosition.y);
                    }
                }
                else
                {
                    bird_is_out = false;
                }


            }


        }




    }
}

