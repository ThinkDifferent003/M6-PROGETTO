using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _maxEnemies;

    private float _nextTimeSpawn;
    private void Awake()
    {
        _nextTimeSpawn = _spawnTime;
    }

    private void SpawnEnemy()
    {
        if (_enemyPrefab ==  null) return;
        Vector2 _spawnPos = transform.position;
        Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.ActiveEnemies.Count >= _maxEnemies)
        {
            return;
        }
        _nextTimeSpawn -= Time.deltaTime;
        if (_nextTimeSpawn <= 0f )
        {
            SpawnEnemy();
            _nextTimeSpawn = _spawnTime;
        }
    }
}
