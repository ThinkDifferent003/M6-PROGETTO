using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpotLightManager : MonoBehaviour
{
    [SerializeField] private float _minLight = 2.0f;
    [SerializeField] private float _maxLight = 10.0f;
    [SerializeField] private float _lightLost = 0.5f;
    private float _currentLight;
    private Light2D _myLight;
    public System.Action<float> OnLightChange;
    public float MaxLight => _maxLight;

    private void Awake()
    {
        _myLight = GetComponent<Light2D>();
        _currentLight = _minLight;
        _myLight.pointLightOuterRadius = _currentLight;
    }
    private void Update()
    {
        if (_currentLight > _minLight)
        {
            _currentLight -= _lightLost * Time.deltaTime;
            _myLight.pointLightOuterRadius = _currentLight;
            OnLightChange?.Invoke(_currentLight);
        }
    }
    private void AddLight(float light)
    {
        _currentLight = Mathf.Clamp(_currentLight +  light, _minLight, _maxLight);
        _myLight.pointLightOuterRadius = _currentLight;
        OnLightChange?.Invoke(_currentLight);
    }

    private void OnEnable()
    {
        LightGem.OnItemCollected += AddLight;
    }
    private void OnDisable()
    {
        LightGem.OnItemCollected -= AddLight;
    }
}
