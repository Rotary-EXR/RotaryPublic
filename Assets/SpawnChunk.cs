using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SpawnChunk : NetworkBehaviour
{
    public GameObject WorldChunk;

    async void Start()
    {

        var world = (GameObject)Instantiate(WorldChunk, new Vector3(64, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(world);
    }

}
