using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MovementNetworkController : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 position, ServerRpcParams serverRpcParams = default) => Position.Value = position;

    void Update()
    {
        if (IsOwner && !IsServer)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveX, 0f, moveZ) * 5 * Time.deltaTime;
            transform.Translate(movement, Space.World);
            SubmitPositionRequestServerRpc(transform.position);
        }
        if (IsServer)
            transform.position = Position.Value;
    }
}