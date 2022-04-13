using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using System.Diagnostics;


// draw and update the graph
public class Window_Graph_UDP: MonoBehaviour
{


    GameObject handler;
    Readtxt_UDP dataclass;


    List<float> valueList = new List<float>() { };
    List<GameObject> objectList = new List<GameObject>() { };
    //List<GameObject> lineList = new List<GameObject>() { };

    int n = 0;
    
    int maxVisibleValueAmount = 350;
    int datapoint_per_update = 5;
    int data_collected_num = 0;

    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;

    public float xPosition;
    public float yPosition;

    float graphHeight;
    float graphWidth;
    float yMaximum = 6f;
    float xSize;

    private void Awake()
    {

        handler = GameObject.Find("GameHandler");
        dataclass = handler.GetComponent<Readtxt_UDP>();


        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();

        // draw Y label
        graphHeight = graphContainer.sizeDelta.y;
        graphWidth = graphContainer.sizeDelta.x;
        Func<float, string> getAxisLabelY = delegate (float _f) { return Math.Round(_f, 1).ToString(); };
        

        int separatorCount = 6;
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 1f / separatorCount;
            labelY.anchoredPosition = new Vector2(-10f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(normalizedValue * yMaximum);

        }


        xSize = graphWidth / (maxVisibleValueAmount + 1);

    }

    private void FixedUpdate()
    {

        // only collect odd data; discard even data
        data_collected_num += 1;
        if (data_collected_num == 1)
        {
            valueList.Add(dataclass.volume);
            n++;

            if (n > maxVisibleValueAmount)
            {
                valueList.RemoveAt(0);
            }

            // redraw the graph again after reading in 5 datapoints
            if (n % datapoint_per_update == 0)
            {
                for (int i = 0; i < valueList.Count; i++)
                {
                    xPosition = i * xSize / 2;
                    yPosition = (valueList[i] / yMaximum) * graphHeight;

                    GameObject dot;

                    if (i < objectList.Count)
                    {
                        dot = objectList[i];

                    }
                    else //(i = objectList.Count) create the first 350 dots
                    {
                        dot = CreateCircle(new Vector2(xPosition, yPosition), i);
                        objectList.Add(dot);

                    }
                    dot.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPosition, yPosition);

                }
                
                // n will be bounded under 700
                if (n > 2 * maxVisibleValueAmount)
                {
                    n -= maxVisibleValueAmount;
                }
            }
        }

        else if (data_collected_num == 2)
        {
            data_collected_num -= 2;
        }
    }

    private GameObject CreateCircle(Vector2 anchoredPosition, int i)
    {
        GameObject gameObject = new GameObject("circle" + i, typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(5, 5);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }


}
