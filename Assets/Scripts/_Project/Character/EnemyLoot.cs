using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _lightGemPrefab;
    [SerializeField] private float _heatDrop = 20.0f;
    [SerializeField] private float _gemDrop = 40.0f;
    private LifeController _lifeController;

    private void Awake()
    {
        _lifeController = GetComponent<LifeController>();
    }

    private void Drop()
    {
        float randomDrop = Random.Range(0f, 101f);

        if (randomDrop <= _heatDrop )
        {
            Instantiate(_heartPrefab,transform.position, Quaternion.identity);
            return;
        }
        randomDrop = Random.Range(0f, 101f);
        if (randomDrop <= _gemDrop )
        {
            Instantiate(_lightGemPrefab,transform.position, Quaternion.identity);
        }
    }
    private void OnEnable()
    {
        if ( _lifeController != null )
        {
            _lifeController.OnDeath += Drop;
        }
    }
    private void OnDisable()
    {
        if (_lifeController != null )
        {
            _lifeController.OnDeath -= Drop;
        }
    }
}
