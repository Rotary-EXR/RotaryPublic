using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRenderer : MonoBehaviour
{
    
   
    public float distanceToAppear = 8;
    Renderer objRenderer;
    public GameObject tree;
    float view = 0;
    public Transform Playercam;
    public Transform treeView;
    void Start()
    {
        //mainCamTransform = Playercam.transform;//Get camera transform reference
        objRenderer = gameObject.GetComponent<Renderer>(); //Get render reference
    }
    void Update()
    {
        var x1 = Mathf.RoundToInt(Playercam.position.x);
        var z1 = Mathf.RoundToInt(Playercam.position.z);
        var xT = Mathf.RoundToInt(treeView.position.x);

        var xT1 = xT - x1;
        // We have reached the distance to Enable Object
        if (xT1 > distanceToAppear)
        {
            Debug.Log("detect");
            if (view == 1)
            {
                tree.SetActive(true);// Show Object

                Debug.Log("Visible");
                view = 0;
            }
        }
        else if (view == 0)
        {
            tree.SetActive(false); // Hide Object

            Debug.Log("InVisible");
            view = 1;
        }
    }
   
}
