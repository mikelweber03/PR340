using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MovementNetworkController : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
    [SerializeField]
    public float speed = 5f;

    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 position, ServerRpcParams serverRpcParams = default) => Position.Value = position;

    //Thought this would sync the movements in each players build, so one player can see the other moving
   // [ClientRpc]
   // void SubmitPositionRequestClientRpc(Vector3 position, ClientRpcParams clientRpcParams = default) => Position.Value = position;
        
    void Update()
    {
        
        if (IsOwner && !IsServer)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveX, 0f, moveZ) * speed * Time.deltaTime;
            transform.Translate(movement, Space.World);
            SubmitPositionRequestServerRpc(transform.position);
            
            //SubmitPositionRequestClientRpc(transform.position);
            
        }
        if (IsServer)
            transform.position = Position.Value;
    }
}