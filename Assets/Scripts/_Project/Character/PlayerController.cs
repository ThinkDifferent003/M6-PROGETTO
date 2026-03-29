using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintMultiplier;
   
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private bool _isSprinting;
    private bool _canMove = true;
    public Vector2 Direction
        { get => _direction; }
  
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        LifeController life = GetComponent<LifeController>();
        if (life != null)
        {
            life.OnDeath += DisableMovement;
        }
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _direction = new Vector2(horizontal, vertical).normalized;
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void FixedUpdate()
    {
        if (!_canMove)
        {
            _rb.velocity = Vector2.zero;
            return;
        }
        Move();
    }

    private void Move()
    {
        float playerSpeed = _speed;
        if (_isSprinting)
        {
            playerSpeed = _speed * _sprintMultiplier;
        }
        Vector2 velocity = _direction * playerSpeed;
        _rb.MovePosition(_rb.position + velocity * Time.fixedDeltaTime);
    }

    private void DisableMovement()
    {
        _canMove = false;
    }

    private void OnDestroy()
    {
        LifeController life = GetComponent<LifeController>();
        if (life != null)
        {
            life.OnDeath -= DisableMovement;
        }
    }
}
