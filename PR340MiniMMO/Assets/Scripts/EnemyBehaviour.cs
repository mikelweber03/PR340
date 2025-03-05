using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.Animations;

public class EnemyBehaviour : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private NetworkVariable<Vector3> targetPosition = new NetworkVariable<Vector3>();
    UnityEngine.AI.NavMeshAgent enemyAgent;

    private void Start()
    {
        enemyAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Update()
    {
 
        if (!IsServer) return;

        // Find nearest player
        GameObject nearestPlayer = FindNearestPlayer();
        print("chasing1");
        if (nearestPlayer != null)
        {
            // Move towards the player
            enemyAgent.SetDestination(nearestPlayer.transform.position);
            //Vector3 direction = (nearestPlayer.transform.position - transform.position).normalized;
            //targetPosition.Value = transform.position + direction * moveSpeed * Time.deltaTime;
            //transform.position = targetPosition.Value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //   // Check if enemy touches a player
        //   GameObject player = other.GameObject();
        //   if (player != null)
        //   {
        //       // Eliminate player, gotta set each player active again each round
        //       player.SetActive(false);
        //   }
        print("Player has been tagged");
    }

    private GameObject FindNearestPlayer()
    {
        
        print("chasing2");
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