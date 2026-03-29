using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private LifeController _bossLife;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void UpdateBar(int currentHealth)
    {
        float healthForBar = (float)currentHealth / _bossLife.MaxHealth;
        if (_healthBar  != null )
        {
            _healthBar.fillAmount = healthForBar;
        }
    }

    private void OnEnable()
    {
        if (_bossLife != null )
        {
            _bossLife.OnHealthChange += UpdateBar;
        }
    }
    private void OnDisable()
    {
        if (_bossLife != null )
        {
            _bossLife.OnHealthChange -= UpdateBar;
        }
    }
}
