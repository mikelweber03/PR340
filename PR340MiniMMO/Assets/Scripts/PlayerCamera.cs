using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Mathematics;
public class PlayerCamera : NetworkBehaviour
{
     public Vector3 offset;
     public Quaternion rotation;

    private void Start()
    {
        if(IsOwner)
        {
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.parent = transform;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.position += offset;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.transform.rotation = rotation;
        }

    }
}
