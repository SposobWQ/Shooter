using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Vector3 _moveVector;
    public float _speed;
    public float _jumpforce;
    private CharacterController _chcontr;
    private float gravity = 9.8f;
    [SerializeField] private float _fallVelocity;
    void Start()
    {
        _chcontr = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& _chcontr.isGrounded)
        {
            _fallVelocity = -_jumpforce;
        }
        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _chcontr.Move(_moveVector * _speed * Time.fixedDeltaTime);
        _chcontr.Move(Vector3.down * _fallVelocity * Time.deltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        if (_chcontr.isGrounded)
        {
                _fallVelocity = 0;
        }



    }
}
