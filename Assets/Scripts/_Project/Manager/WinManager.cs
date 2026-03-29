using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private LifeController _bossLife;

    private void Start()
    {
        if (_winPanel != null)
        {
            _winPanel.SetActive(false);
        }
    }
    private void Win()
    {
        if (_winPanel != null)
        {
            _winPanel.SetActive(true);
        }

        Time.timeScale = 0.2f;
    }
    private void OnEnable()
    {
        if (_bossLife != null)
        {
            _bossLife.OnDeath += Win;
        }
    }
    private void OnDisable()
    {
        if (_bossLife != null)
        {
            _bossLife.OnDeath -= Win;
        }
    }
}
