using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyBehaviour : NetworkBehaviour
{
    private NetworkVariable<Vector3> targetPosition = new NetworkVariable<Vector3>();
    UnityEngine.AI.NavMeshAgent enemyAgent;
    public NetworkVariable<Vector3> currentPosition = new NetworkVariable<Vector3>();
    public bool gameOver = false;
    
    private void Start()
    {
        enemyAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Update()
    {

        // Find nearest player
        GameObject nearestPlayer = FindNearestPlayer();
        if (nearestPlayer != null)
        {
            // Move towards the player
            enemyAgent.SetDestination(nearestPlayer.transform.position);
            if(IsOwner)
            {
            SubmitPositionRequestServerRpc(transform.position);
            }
        }
    }
    [ServerRpc]
    void SubmitPositionRequestServerRpc(Vector3 position, ServerRpcParams serverRpcParams = default) => currentPosition.Value = position;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!IsServer)
            {
                GameObject player = other.GameObject();
                if (player != null)
                {
                    player.tag = "caught";
                    //player.GetComponent<Material>().color = Color.red;
                    //For some reson unity doesn't recognize Player(clone) to have a material and the Text UI didn't work either
                    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                    print("Player has been tagged");
                    if (players.Length == 1)
                    {
                        Time.timeScale = 0f;
                        gameOver = true;
                        //player.GetComponent<Material>().color = Color.yellow;
                    }
                }
            }
        }
    }

    private GameObject FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearest = null;
        float minDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = player;
            }
        }

        return nearest;
    }
}