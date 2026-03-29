using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController _playerLife = other.GetComponent<LifeController>();
            if (_playerLife != null && _playerLife.CurrentHealth < _playerLife.MaxHealth )
            {
                _playerLife.HealLife(_health);
                Destroy(gameObject);
            }
        }

    }
}    
