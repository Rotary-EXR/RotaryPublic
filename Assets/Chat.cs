using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
public class Chat : NetworkBehaviour
{
    [SerializeField] private Text chatText = null;
    [SerializeField] private InputField inputField = null;
    [SerializeField] private GameObject canvas = null;
    //[SerializeField] private GameObject Inv = null;
    public GameObject PlayerName;
    private float chat = 0;
    private float name = 0;
    private static event Action<string> OnMessage;

    // Called when the a client is connected to the server
    public override void OnStartAuthority()
    {
        if (isLocalPlayer) { canvas.SetActive(true);
           // Inv.SetActive(true);
            string name;
            name = PlayerName.name;
            CmdJoin(name);

        }

        OnMessage += HandleNewMessage;

    }


    // Called when a client has exited the server
    [ClientCallback]
    private void OnDestroy()
    {
        if (!hasAuthority) { return; }

        OnMessage -= HandleNewMessage;
        string name;
        name = PlayerName.name;
        CmdLeft(name);
    }
    private void OnPlayerDisconnected()
    {
        if (!hasAuthority) { return; }

        OnMessage -= HandleNewMessage;
        string name;
        name = PlayerName.name;
        CmdLeft(name);
    }
    // When a new message is added, update the Scroll View's Text to include the new message
    private void HandleNewMessage(string message)
    {
        chatText.text += message;
    }
    [Client]
    public async void Left()
    {
        StartCoroutine(StartLeft());



    }
    private IEnumerator StartLeft()
    {
        CmdLeft(PlayerName.name);
        yield return new WaitForSeconds(0.2f);
        Disc();

    }
    // When a client hits the enter button, send the message in the InputField
    [Client]
    public void Send()
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }
        if (string.IsNullOrWhiteSpace(inputField.text)) { return; }
        if (inputField.text == "/ping")
        {
            Debug.Log("pong");
            OnMessage?.Invoke($"\n" + $"PONG !");
            inputField.text = string.Empty;
        }
        else if (inputField.text == "/help")
        {

            //OnMessage?.Invoke($"\n" + $"Votre version : SP070521-PublicBuild");
            OnMessage?.Invoke($"\n" + $"Command list :");
            OnMessage?.Invoke($"\n" + $"/help");
            OnMessage?.Invoke($"\n" + $"/ping");
            OnMessage?.Invoke($"\n" + $"/name");
            inputField.text = string.Empty;
        }
        else if (inputField.text == "/name")
        {

            OnMessage?.Invoke($"\n" + $"Met ton nom");
            inputField.text = string.Empty;
            name = 1;

        }
        else if (name == 1)
        {
            Name(inputField.text);
            CmdName(inputField.text);
            name = 0;
            inputField.text = string.Empty;
        }
        else
        {
            CmdSendMessage(inputField.text);
            inputField.text = string.Empty;
        }

    }
    private void Name(string name)
    {
        PlayerName.name = name;
        OnMessage?.Invoke($"\n" + $"ton nom est maintenant : " + $"[{PlayerName.name}]");
    }
    [Command]
    private void CmdSendMessage(string message)
    {
        // Validate message
        RpcHandleMessage($"[{PlayerName.name}] : {message}");
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + $"[{PlayerName.name}] > {message}");
    }
    [Command]
    private void CmdJoin(string name)
    {
        // Validate message
        RpcHandleMessage(name +$" a rejoint");
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : "+ name + $" a rejoint");
    }
    [Command]
    private void CmdLeft(string name)
    {
        // Validate message
        RpcHandleMessage(name + $" est parti");
        UnityEngine.Debug.Log(System.DateTime.Now.ToLongTimeString() + " : " + name + $" est parti");

    }
    [Client]
    public void Disc()
    {

        NetworkManager.singleton.StopClient();
        //NetworkManager.singleton.StopHost();
    }
    [Command]
   private void CmdName(string name)
    {
        RpcName(name);
        PlayerName.name = name;
        OnMessage?.Invoke($"\n"+$"ton nom est maintenant : " + $"[{PlayerName.name}]");
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke($"\n{message}");
    }
    [ClientRpc]
    private void RpcName(string name)
    {
        PlayerName.name = name;
    }
    void Update()
    {
        if (!isLocalPlayer) { return; };
        if (Input.GetKey("t"))
        {
            if (inputField.isFocused) { return; }
            inputField.Select();
            inputField.ActivateInputField();
        }

    }
    }
