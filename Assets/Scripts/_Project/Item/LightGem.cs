using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGem : MonoBehaviour
{
    [SerializeField] private float _lightBonus = 0.5f;
    public static Action<float> OnItemCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemCollected?.Invoke(_lightBonus);
            Destroy(gameObject);
        }
    }
}
