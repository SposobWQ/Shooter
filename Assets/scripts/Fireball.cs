using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float _damage;
    public float _lifetime;
    public float _speed;
    private void Start()
    {
        Invoke("DestroyFireball", _lifetime);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
        
    }

    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Time.fixedDeltaTime * _speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        DamageEnemyCollision(collision);
        DestroyFireball();
        
    }

    private void DamageEnemyCollision(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(_damage);
        }
    }
    private void DestroyFireball()
    {
        Destroy(gameObject);
    }

   


}
