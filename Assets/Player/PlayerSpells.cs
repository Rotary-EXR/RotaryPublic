using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerSpells : NetworkBehaviour
{
    public GameObject PlayerLocal;
   // public GameObject fireballLaunch;
    //public Transform fireballSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) { return; };

        if (Input.GetKey("a"))
            {
            PlayerLocal.GetComponent<Animator>().Play("Fireball", -1, 0f);
           // Fireball();
            }

        if (Input.GetKeyDown("z"))
        {
            PlayerLocal.GetComponent<Animator>().Play("InWalk", -1, 0f);
            
        }
        if (Input.GetKeyDown("s"))
        {
            PlayerLocal.GetComponent<Animator>().Play("InWalk", -1, 0f);

        }
        //else { PlayerLocal.GetComponent<Animator>().Play("Fireball", -1, 0f);}
    }
   
}
