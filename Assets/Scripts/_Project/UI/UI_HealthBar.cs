using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private LifeController _playerLifeController;

    private void OnEnable()
    {
        if (_playerLifeController  != null)
        {
            _playerLifeController.OnHealthChange += UpdateBar;
        }
        
    }

    private void OnDisable()
    {
        if ( _playerLifeController != null )
        {
            _playerLifeController.OnHealthChange -= UpdateBar;
        }
    }

    private void UpdateBar(int currentHealth)
    {
        float healtForBar = (float)currentHealth / _playerLifeController.MaxHealth;
        if (_healthBar != null)
        {
            _healthBar.fillAmount = healtForBar;
        }
    }
}
