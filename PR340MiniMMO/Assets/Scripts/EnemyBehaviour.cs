using Unity.Netcode;
 using UnityEngine;
public class EnemyBehaviour : NetworkBehaviour
{

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        Debug.Log("Spawned enemy");
    }
}