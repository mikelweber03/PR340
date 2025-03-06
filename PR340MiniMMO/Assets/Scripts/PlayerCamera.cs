using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Mathematics;
public class PlayerCamera : NetworkBehaviour
{
    // 
    // [SerializeField]
    // private GameObject player;
     public Vector3 offset;
     public Quaternion rotation;
    //
    // public override void OnNetworkSpawn()
    // { // This is basically a Start method
    //     if (IsOwner)
    //     {
    //         GetComponent<Camera>().enabled = true;
    //     }
    //     else
    //     {
    //         GetComponent<Camera>().enabled = false;
    //     }
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     transform.position = player.transform.position + offset;
    //     transform.rotation = rotation;
    // }

    private void Start()
    {
        if(IsOwner)
        {
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.parent = transform;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position = GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position + offset;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.rotation = rotation;
        }

    }
}
