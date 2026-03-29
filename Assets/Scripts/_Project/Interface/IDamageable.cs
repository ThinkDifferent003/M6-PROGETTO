using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(int damage)
    {

    }
    System.Action OnDeath {  get; set; }
}
