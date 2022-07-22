using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _speedMovement;
    [SerializeField] private List<GameObject> _nets = new List<GameObject>();

    private GameObject _activeNet;

    private const float _gravity = -9.81f;

    private Animator _animator;

    private List<Prisoner> _prisoners = new List<Prisoner>();

    private CharacterController _conroller;

    public static Player instance;

    public List<Prisoner> Prisoners => _prisoners;

    private Vector3 _gravityVelocity;

    public bool IsGrab => _prisoners.Count > 0;

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
        _activeNet = _nets[1];
        ActivateNet();
    }

    public void GrabPrisoner(Prisoner prisoner)
    {
        _animator.SetTrigger("catch");
        _prisoners.Add(prisoner);
    }

    public void DropPrisoners()
    {
        for(int i = 0; i < Prisoners.Count; i++)
        {
            _prisoners[i].transform.SetParent(null);
        }
        _prisoners.Clear();
        ActivateNet();
    }

    public void ActivateNet()
    {
        _nets[_prisoners.Count].SetActive(true);
        _activeNet.SetActive(false);
        _activeNet = _nets[_prisoners.Count];
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
