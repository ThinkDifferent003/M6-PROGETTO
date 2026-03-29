using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    [SerializeField] private Vector3 _equipmentVector = new Vector3 (0.5f,0,0);
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRange;
    [SerializeField] private float _fireRate;
    [SerializeField] private Transform _firePoint;
    
    private Transform _enemy;
    [SerializeField] private float _bulletSpeed;
    private float _lastShoot;
    

    private void Update()
    {  
        if (IfCanShoot())
        {
            _enemy = CloseestEnemy();
            if (_enemy != null)
            {
                Shoot();
            }
        }
    }
   
    private Transform CloseestEnemy()
    {
        List<Enemy> enemies = GameManager.Instance.ActiveEnemies;
        Transform closest = null;
        float minDistance = _fireRange * _fireRange;
        Vector2 currentPos = transform.position;
        
        foreach (var enemy in enemies)
        {
            if (enemy == null) continue;
            float distance = ((Vector2)enemy.transform.position - currentPos).sqrMagnitude;
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }
        return closest;
    }
    private bool IfCanShoot()
    {
        float _shootTime = _lastShoot + _fireRate;
        if (Time.time >= _shootTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Shoot()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayEffectClip(AudioManager.Instance.ShootClip);
        }
        if (_enemy == null) return;
        _lastShoot = Time.time;
        SpawnBullet();
    }

    private void SpawnBullet()
    {
        if (_enemy == null) return;
        Vector2 direction = (_enemy.position - _firePoint.position).normalized;
        GameObject bulletObj = Instantiate(_bulletPrefab , _firePoint.position, Quaternion.identity);
        bulletObj.transform.up = direction;
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Initialize(direction,_bulletSpeed);
        }
    }

   
}
