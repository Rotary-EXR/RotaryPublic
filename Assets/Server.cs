using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class Server : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Server start");
        NetworkManager.singleton.StartServer();
    }

}
