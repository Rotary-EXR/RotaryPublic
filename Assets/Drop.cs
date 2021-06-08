using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
public class Drop : NetworkBehaviour
{
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {

    }
    public GameObject drop;//your sword

    private void OnDestroy() //called, when enemy will be destroyed
    {

        if (!isClient) //Temporairement désactivé, fait planté le  client si le serveur est fermé ou si le client se déconnecte
        {
           // var Stone = (GameObject)Instantiate(drop, transform.position, drop.transform.rotation);
           // NetworkServer.Spawn(Stone);
        }


    }





    // Update is called once per frame
    void Update()
    {

    }
}
