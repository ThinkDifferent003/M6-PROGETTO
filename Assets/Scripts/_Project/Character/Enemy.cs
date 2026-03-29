using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected int _damage;
    

    protected Transform _playerTransform;
    protected Rigidbody2D _rb;
    protected Animator _animator;
    protected LifeController _lifeController;

    [SerializeField] protected string _xDirection = "XDirection";
    [SerializeField] protected string _yDirection = "YDirection";
    [SerializeField] protected string _isMoving = "IsMoving";
    [SerializeField] protected string _isDead = "IsDead";

    protected bool _dead = false;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();

        _lifeController.OnDeath += HandleDeath;
    }

    protected virtual void Start()
    {
        GameManager.Instance?.RegisterEnemy(this);
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }


    protected virtual void FixedUpdate()
        {
            if (_dead || _playerTransform == null) return;

            Vector2 _direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
            _rb.velocity = _direction * _speed;
            
            bool _moving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
         _animator.SetBool(_isMoving , _moving);
          if (_moving)
           {
              _animator.SetFloat(_xDirection , _direction.x);
              _animator.SetFloat(_yDirection , _direction.y);
           }
        }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (_dead) return;
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            damageable?.TakeDamage(_damage);
            _lifeController.Die();
        }

    }
    protected virtual void UpdateAnimation(Vector2 direction)
    {
        bool isMovingDir = _rb.velocity.sqrMagnitude > 0.01f;
        _animator.SetBool(_isMoving, isMovingDir);
        if (isMovingDir)
        {
            _animator.SetFloat(_xDirection , direction.x);
            _animator.SetFloat(_yDirection , direction.y);
        }
    }
    
    protected virtual void MoveToPlayer()
    {
        Vector2 direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
        _rb.velocity = direction * _speed;
        UpdateAnimation(direction);
    }

    protected void HandleDeath()
    {
        if (_dead) return;
        _dead = true;
        _rb.velocity = Vector2.zero;
        _rb.simulated = false;
        _animator.SetTrigger(_isDead);
        GameManager.Instance?.UnRegisterEnemy(this);
    }

    private void OnDestroy()
    {
        if (_lifeController  != null)
        {
            _lifeController.OnDeath -= HandleDeath;
        }
    }
}

