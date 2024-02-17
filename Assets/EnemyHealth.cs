using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float _health;

    public void DealDamage(float _damage)
    {
        _health -= _damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
