using Unity.Netcode;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour enemy;
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 10f, 15f);
    }
    private void SpawnEnemy()
    {
        EnemyBehaviour instantiatedEnemy = Instantiate(enemy);
        instantiatedEnemy.GetComponent<NetworkObject>().Spawn();
    }
}