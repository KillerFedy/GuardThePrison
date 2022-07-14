using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speedMovement;

    private Rigidbody _rigidbody;

    public static PlayerView instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _speedMovement = 5f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Vertical * _speedMovement, _rigidbody.velocity.y, -_joystick.Horizontal * _speedMovement);
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }
}
