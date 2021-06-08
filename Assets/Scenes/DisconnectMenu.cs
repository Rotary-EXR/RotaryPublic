using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class DisconnectMenu : NetworkBehaviour
{
    public GameObject PlayerName;
    public void SetupMenu()
    {
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(StopHostAndClient);
    }
 
    public void SetupDisconnectMenu()
    {
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(StopHostAndClient);
    }
    public void StopHostAndClient()
    {

        NetworkManager.singleton.StopClient();
        //NetworkManager.singleton.StopHost();

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
            SetupDisconnectMenu();
        }
    }
    private void Update()
    {

        SetupMenu();

    }
}
