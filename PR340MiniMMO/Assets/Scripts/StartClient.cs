using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class StartClient : MonoBehaviour
{
    public void Start()
    {
        if (NetworkManager.Singleton != null)
            NetworkManager.Singleton.StartClient();
    }
}

