using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform _target;
    public Camera _cameralink;
    public float _inskyDistance;

    void Update()
    {
        var ray = _cameralink.ViewportPointToRay(new Vector3(0.5f, 0.59f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {   
            _target.position = hit.point;
        }
        else
        {
            _target.position = ray.GetPoint(_inskyDistance);
        }
        transform.LookAt(_target.position);  
    }
}
