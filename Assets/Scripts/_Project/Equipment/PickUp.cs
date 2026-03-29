using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject _gunPrefab;
    private Vector3 _equipmentVector = new Vector3(0.5f, 0, 0);
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject gun = Instantiate(_gunPrefab, other.transform);
            gun.transform.localPosition = _equipmentVector;
            gun.transform.localRotation = Quaternion.identity;
            Destroy(gameObject);
        }
    }
}
