using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;
    private LifeController _lifeController;
   
    [SerializeField] private string _isMoving = "IsMoving";
    [SerializeField] private string _xDirection = "XDirection";
    [SerializeField] private string _yDirection = "YDirection";
    [SerializeField] private string _isDead = "IsDead";
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();
        if (_lifeController != null )
        {
            _lifeController.OnDeath += PlayDeathAnimation;
        }
    }
    void Update()
    {
        if (_playerController == null || _animator == null) return;
        MovementAnimation();
    }

    private void MovementAnimation()
    {
        Vector2 direction = _playerController.Direction;
        bool isMovingDir = direction.sqrMagnitude > 0.01f;
        _animator.SetBool( _isMoving, isMovingDir );
        if ( isMovingDir )
        {
            _animator.SetFloat (_xDirection , direction.x);
            _animator.SetFloat (_yDirection , direction.y);
        }
    }

    private void PlayDeathAnimation()
    {
        _animator.SetTrigger(_isDead);
    }

    public void DeathClip()
    {
        if (AudioManager.Instance !=  null)
        {
            AudioManager.Instance.PlayDeathClip();
        }
    }
    private void OnDestroy()
    {
        if (_lifeController != null)
        {
            _lifeController.OnDeath -= PlayDeathAnimation;
        }
    }
}
