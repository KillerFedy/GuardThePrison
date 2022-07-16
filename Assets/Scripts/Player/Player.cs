using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speedMovement;

    private List<Prisoner> _prisoners = new List<Prisoner>();

    private Rigidbody _rigidbody;

    public static Player instance;

    public List<Prisoner> Prisoners => _prisoners;

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
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void GrabPrisoner(Prisoner prisoner)
    {
        _prisoners.Add(prisoner);
    }

    public void DropPrisoners()
    {
        for(int i = 0; i < Prisoners.Count; i++)
        {
            _prisoners[i].transform.SetParent(null);
        }
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
