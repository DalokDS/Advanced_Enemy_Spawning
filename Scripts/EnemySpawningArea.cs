using System.Collections;
using UnityEngine;

public class EnemySpawningArea : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _enemySpawners;
    [SerializeField] private float _spawningDuration;
    [SerializeField] private int _maxSpawnedEnemyCount;

    private void Start()
    {
        _enemySpawners = GetComponentsInChildren<EnemySpawner>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSpawningDuration = new WaitForSeconds(_spawningDuration);

        for (int i = 0; i < _maxSpawnedEnemyCount; i++)
        {
            int enemySpawnerIndex = Random.Range(0, _enemySpawners.Length);
            _enemySpawners[enemySpawnerIndex].SpawnEnemy();

            yield return waitForSpawningDuration;
        }
    }
}
