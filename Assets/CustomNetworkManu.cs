using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CustomNetworkManu : MonoBehaviour
{
    // public Text ipText;
    //public Text portText;
    // Start is called before the first frame update
    public void SetupMenu()
    {

        // GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
        // GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartServer);
        

        GameObject.Find("ButtonJoinClient").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonJoinClient").GetComponent<Button>().onClick.AddListener(JoinClient);

        GameObject.Find("ButtonHelp").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonHelp").GetComponent<Button>().onClick.AddListener(Help);
    }
    public void Help()
    {
        SceneManager.LoadScene("Help", LoadSceneMode.Single);

    }
   
    public void JoinClient()
    {
        string ip = GameObject.Find("TextIP").GetComponent<Text>().text;
        string port = GameObject.Find("TextPort").GetComponent<Text>().text;
        if (ip.Length > 0)
        {
            NetworkManager.singleton.networkAddress = ip;
        }
        if (port.Length > 0)
        {
            int x;
            int.TryParse(port, out x);
            NetworkManager.singleton.networkPort = x;
        }
        NetworkManager.singleton.StartClient();
    }
    public void SetupDisconnectMenu() // REPLACE WITH TRUE MENU
    {
     // GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
     // GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(StopHostAndClient);
    }
    public void StopHostAndClient()
    {
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            SetupMenu();
        }
        else
        {
         // SetupDisconnectMenu();
        }
    }
    private void Update()
    {
     
            SetupMenu();
       
    }
}
