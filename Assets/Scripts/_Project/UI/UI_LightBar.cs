using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LightBar : MonoBehaviour
{
    [SerializeField] private Image _lightBar;
    [SerializeField] private SpotLightManager _spotLightManager;

    private void UpdateBar(float currentLight)
    {
        float lightForBar = currentLight / _spotLightManager.MaxLight;
        if (_lightBar  != null )
        {
            _lightBar.fillAmount = lightForBar;
        }
    }

    private void OnEnable()
    {
        if (_spotLightManager != null )
        {
            _spotLightManager.OnLightChange += UpdateBar;
        }
    }
    private void OnDisable()
    {
        if ( _spotLightManager != null )
        {
            _spotLightManager.OnLightChange -= UpdateBar;
        }
    }
}
