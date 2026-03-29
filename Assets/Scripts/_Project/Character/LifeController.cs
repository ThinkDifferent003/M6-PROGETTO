using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour , IDamageable
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    
    [SerializeField] private float _delayDestroy = 1.5f;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;
    public Action OnDeath {  get; set; }
    public Action<int> OnHealthChange;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage (int _damage )
    {
        _currentHealth -= _damage;
        Debug.Log($"{gameObject.name} ha subito {_damage} danni!");
        Debug.Log($"Vita rimanente: {_currentHealth}");
        OnHealthChange?.Invoke( _currentHealth );

        if ( _currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealLife(int _heal)
    {
        _currentHealth = Mathf.Min( _currentHealth + _heal,_maxHealth );
        Debug.Log($"Vita rimanente a {_currentHealth}");
        OnHealthChange?.Invoke(_currentHealth );
    }

    public void Die()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayDeathClip();
        }
        OnDeath?.Invoke();
        Debug.Log($"Il personaggio {gameObject.name} è stato sconfitto!");
        Destroy(gameObject , _delayDestroy);
    }
   
}
