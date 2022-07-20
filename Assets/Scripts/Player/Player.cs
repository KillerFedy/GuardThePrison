using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speedMovement;

    private const float _gravity = -9.81f;

    private Animator _animator;

    private List<Prisoner> _prisoners = new List<Prisoner>();

    private CharacterController _conroller;

    public static Player instance;

    public List<Prisoner> Prisoners => _prisoners;

    private Vector3 _gravityVelocity;

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
        _conroller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat("magnitudeDirection", 1);
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
        Vector3 direction = new Vector3(-_joystick.Vertical * _speedMovement, -1, _joystick.Horizontal * _speedMovement);
        _conroller.Move(direction * Time.fixedDeltaTime);
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_conroller.velocity);
        }
        _gravityVelocity.y += _gravity * Time.fixedDeltaTime;
        _conroller.Move(_gravityVelocity * Time.fixedDeltaTime);
        _animator.SetFloat("magnitudeDirection", direction.magnitude);
    }
}
