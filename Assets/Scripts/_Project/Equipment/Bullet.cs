using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _autoDestroy;
    private float _bulletSpeed;
    private Vector2 _direction;
    Rigidbody2D _rb;

    public void Initialize(Vector2 _travelDirection , float _travelSpeed) 
    {
        _direction = _travelDirection;
        _bulletSpeed = _travelSpeed;
        
        _rb = GetComponent<Rigidbody2D>();
        if ( _rb != null )
        {
            _rb.velocity = _direction * _bulletSpeed;
        }
        Destroy(gameObject,_autoDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }

}




   