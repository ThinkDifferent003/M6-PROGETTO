using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private float _rangeAggro;
    [SerializeField] private GameObject _bossHealthUI;
    private bool _isBossActive = false;
    
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (_dead) return; 
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null )
            {
                damageable.TakeDamage(_damage);
            }
        }
    }
    

    protected override void FixedUpdate()
    {
        if (_dead || _playerTransform == null)
        {
            if (_dead &&  _bossHealthUI != null)
            {
                _bossHealthUI.SetActive(false);
            }
            return;
        }
        float _distancePlayer = Vector2.Distance(transform.position, _playerTransform.position);
        if (_distancePlayer < _rangeAggro)
        {
            if (!_isBossActive)
            {
                ActiveUI();
            }
            base.MoveToPlayer();
            Debug.LogWarning("TI INSEGUO!");
        }
        else
        {
            _rb.velocity = Vector2.zero;
            UpdateAnimation(Vector2.zero);
        }
    }

    private void ActiveUI()
    {
        _isBossActive = true;
        if (_bossHealthUI != null )
        {
            _bossHealthUI.SetActive(true);
        }
    }
}
