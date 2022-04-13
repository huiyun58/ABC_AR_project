using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// allow user to change background and bird skin at the same time when calling these functions
public class BGSwitch : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;


    GameObject graph_bg;
    GameObject graph_bgl;
    GameObject graph_bgr;

    GameObject bluejay;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Mesh mesh1;
    public Mesh mesh2;
    public Mesh mesh3;



    public void meadow()
    {
        graph_bg = GameObject.Find("graph_background");
        graph_bgl = GameObject.Find("graph_background_left");
        graph_bgr = GameObject.Find("graph_background_right");

        graph_bg.GetComponent<Image>().sprite = sprite1;
        graph_bgl.GetComponent<Image>().sprite = sprite1;
        graph_bgr.GetComponent<Image>().sprite = sprite1;

        bluejay = GameObject.Find("bluejay");
        SkinnedMeshRenderer renderer = bluejay.GetComponent<SkinnedMeshRenderer>();
        renderer.material = mat1;
        renderer.sharedMesh = mesh1;
    }
    public void beach()
    {
        graph_bg = GameObject.Find("graph_background");
        graph_bgl = GameObject.Find("graph_background_left");
        graph_bgr = GameObject.Find("graph_background_right");

        graph_bg.GetComponent<Image>().sprite = sprite2;
        graph_bgl.GetComponent<Image>().sprite = sprite2;
        graph_bgr.GetComponent<Image>().sprite = sprite2;

        bluejay = GameObject.Find("bluejay");
        SkinnedMeshRenderer renderer = bluejay.GetComponent<SkinnedMeshRenderer>();
        renderer.material= mat2;
        renderer.sharedMesh = mesh2;
    }
    public void nightsky()
    {
        graph_bg = GameObject.Find("graph_background");
        graph_bgl = GameObject.Find("graph_background_left");
        graph_bgr = GameObject.Find("graph_background_right");

        graph_bg.GetComponent<Image>().sprite = sprite3;
        graph_bgl.GetComponent<Image>().sprite = sprite3;
        graph_bgr.GetComponent<Image>().sprite = sprite3;

        bluejay = GameObject.Find("bluejay");
        SkinnedMeshRenderer renderer = bluejay.GetComponent<SkinnedMeshRenderer>();
        renderer.material= mat3;
        renderer.sharedMesh = mesh3;
    }

}

