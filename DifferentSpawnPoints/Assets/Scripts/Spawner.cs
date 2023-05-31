using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _enemiesCount;

    private void Start()
    {
        StartCoroutine(SpawnRandomEnemies());
    }

    private IEnumerator SpawnRandomEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        for (int i = 0; i < _enemiesCount; i++)
        {
            Enemy newEnemy = Instantiate(_enemies[Random.Range(0, _enemies.Length)], _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);
            newEnemy.transform.rotation = Quaternion.Euler(0, 180f, 0);

            yield return waitForSeconds;
        }
    }

   

   
}
