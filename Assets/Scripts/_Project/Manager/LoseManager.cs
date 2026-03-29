using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoBehaviour
{
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private LifeController _playerLife;

    private void Start()
    {
        if (_lostPanel != null)
        {
            _lostPanel.SetActive(false);
        }
    }

    private void Lost()
    {
        if ( _lostPanel != null )
        {
            _lostPanel.SetActive(true);
        }
        Time.timeScale = 0f;
        AudioManager.Instance.StopMusic();
    }

    private void OnEnable()
    {
        if (_playerLife != null )
        {
            _playerLife.OnDeath += Lost;
        }
    }
    private void OnDisable()
    {
        if (_playerLife != null )
        {
            _playerLife.OnDeath -= Lost;
        }

                
    }
}
