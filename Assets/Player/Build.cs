using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Build : NetworkBehaviour
{
    public GameObject stone;
    public Vector3 point;
    public Ray ray;
    public Camera myEyes;
    public float distance = 3.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CmdAddCube();

        }
       
    }
    //[Command]
    void CmdAddCube()
    {

        //add cube.
        ray = myEyes.ScreenPointToRay(Input.mousePosition);
        point = ray.origin + (ray.direction * distance);
        var Stone1 = (GameObject)Instantiate(stone, new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z)), Quaternion.identity);
            NetworkServer.Spawn(Stone1);

        
    }
}
