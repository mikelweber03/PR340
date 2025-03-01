using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class StartServer : MonoBehaviour
{
    public void Start()
    {
        if (NetworkManager.Singleton != null)
            NetworkManager.Singleton.StartServer();
    }
}
