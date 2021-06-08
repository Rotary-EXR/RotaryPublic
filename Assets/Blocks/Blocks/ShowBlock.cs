using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEngine.Networking;
public class ShowBlock : NetworkBehaviour
{
#pragma strict
    public GameObject Grass;
   private GameObject block;
    private float range = 30;
    private int state = 1;
    //GameObject[] block;
    private void Start()
    {
        
     
        if (!isServer)
        {
            Debug.Log("check start");
            InvokeRepeating("Check", 0.1f, 0.4f);
        }


       
        


    
}
    void Check()
    {
        
        //Debug.Log("update");
        //block = GameObject.Find("Chunk(Clone)");

        block = GameObject.FindGameObjectWithTag("Player");
        //block1 = block;
        var distance = Vector3.Distance(block.transform.position, transform.position);
        //print(distance);
        if (distance <= range)
        { //this means if the distane is greater than or equal to range
            //Debug.Log("active");
            if (state == 0) {
                for (int a = 0; a < Grass.transform.childCount; a++)
                {
                    Grass.transform.GetChild(a).gameObject.SetActive(true);
                }
                state = 1;
            }
            
            
            //block.SetActive(true); //unhide the gameobject
            //yield return null;
        }
        if (distance > range)
        { //this means if the distane is greater than or equal to range
            if (state == 1)
            {
                for (int a = 0; a < Grass.transform.childCount; a++)
                {
                    Debug.Log("inactive");
                    Grass.transform.GetChild(a).gameObject.SetActive(false);
                }
                state = 0;
            }
            
            //  block.SetActive(false); //hide the gameobject
            //yield return null;
        }

    }
}
