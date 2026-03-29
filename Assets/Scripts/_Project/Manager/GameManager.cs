using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private List<Enemy> _activeEnemies = new List<Enemy>();


    public static GameManager Instance
    { get =>  _instance; }
    public List<Enemy> ActiveEnemies => _activeEnemies;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        if (!_activeEnemies.Contains(enemy))
        {
            _activeEnemies.Add(enemy);
        }
    }
    public void UnRegisterEnemy(Enemy enemy)
    {
        if (_activeEnemies.Contains(enemy))
        {
            _activeEnemies.Remove(enemy);
        }
    }
}
