using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System.Diagnostics;
using System.Runtime.Versioning;


// the script is not in use right now.
// move objects to the left such that the bird needs to cross those barriers like a flappy bird game
public class Move_3D_obj : MonoBehaviour
{
    private GameObject handler;
    Readtxt_UDP dataclass;
    private GameObject graphContainer;
    private RectTransform graphContainer_rect;
    private GameObject obj;

    List<float> valueList = new List<float>() { };
    List<GameObject> objList = new List<GameObject>() { };
    int passedCount = 2000;

    int i = 0;
    int count = 0;
    int maxVisibleValueAmount = 250;
    private int rand;

    public List<GameObject> objs;

    int countdownTime;

    float y_coin;

    private void Awake()
    {
        handler = GameObject.Find("GameHandler");
        dataclass = handler.GetComponent<Readtxt_UDP>();

        graphContainer = GameObject.Find("graphContainer");
        graphContainer_rect = graphContainer.GetComponent<RectTransform>();

        obj = GameObject.Find("tree");
        obj.SetActive(false);
    }

    private void FixedUpdate()
    {
        
        float graphWidth = graphContainer_rect.sizeDelta.x;
        float graphHeight = graphContainer_rect.sizeDelta.y;
        float xSize = graphWidth / (maxVisibleValueAmount + 1) / 2;
        float yMaximum = 3f;
        

        valueList.Add(dataclass.volume);
        i++;


        passedCount++;

        if (dataclass.volume > dataclass.threshold)
        {
            countdownTime = handler.GetComponent<CountDownController_mode2>().countdownTime;

            if (passedCount > 50 && countdownTime > 1)
            {

                passedCount = 0;
                float xPosition = (maxVisibleValueAmount + 100) * 2 * xSize;
                
                

                //int rand = UnityEngine.Random.Range(0, 3);
                int rand = UnityEngine.Random.Range(0, 1);
                GameObject newobj = Instantiate(objs[rand]);
                newobj.SetActive(true);
                count++;
                newobj.name = "obj" + count;
                newobj.transform.SetParent(graphContainer_rect, false);
                //newobj.transform.position = new Vector3(xPosition - graphWidth / 2, -30f, 98f);
                y_coin = (dataclass.threshold + 0.2f) / yMaximum * graphHeight - graphHeight / 2;
                newobj.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition - graphWidth / 2, y_coin);
                objList.Add(newobj);
            }
        }

        if (i > maxVisibleValueAmount)
        {
            valueList.RemoveAt(0);
            i -= 1;
        }

        for (int j = 0; j < objList.Count; j++)
        {
            float x = objList[i].GetComponent<RectTransform>().anchoredPosition.x;
            y_coin = (dataclass.threshold +0.2f) / yMaximum * graphHeight - graphHeight / 2;
            objList[j].GetComponent<RectTransform>().anchoredPosition = new Vector2(x-5*xSize, y_coin);

            //if (x < -xSize * 100)
            if (x < 10)
            {
                GameObject del_obj = objList[0];
                objList.RemoveAt(0);
                Destroy(del_obj);
            }
        }
    }


}



