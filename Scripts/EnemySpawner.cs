using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;

    public void SpawnEnemy()
    {
        Enemy spawnedEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        spawnedEnemy.Init(_target);
    }
}