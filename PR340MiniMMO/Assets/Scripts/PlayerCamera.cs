using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Mathematics;
public class PlayerCamera : NetworkBehaviour
{
    
    [SerializeField]
    private GameObject player;
    public Vector3 offset;
    public quaternion rotation;
   
    public override void OnNetworkSpawn()
    { // This is basically a Start method

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = rotation;
    }
}
