using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SpawnWorld : NetworkBehaviour
{
    public GameObject WorldSpawn;

async public override void OnStartServer()
    {

        var world = (GameObject)Instantiate(WorldSpawn, new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(world);
    }


}
