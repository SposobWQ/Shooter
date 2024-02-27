using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public Transform _caster;
    public Fireball _fireballPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
          Instantiate(_fireballPrefab, _caster.position, _caster.rotation);
          
        }
    }
}
