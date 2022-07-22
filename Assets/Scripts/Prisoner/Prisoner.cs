using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    [SerializeField]private SkinnedMeshRenderer _meshRenderer;

    [SerializeField] private float _timeToUnlock;

    [SerializeField] private int _timeToChangeDirection;
    [SerializeField] private int _countStepsChangeDirection;

    private const float _timeToGrabbed = 0.12f;

    private NavMeshAgent _agent;
    private Transform _point;
    private bool _isRunning = true;
    private Animator _animator;
    private float _speed = 3.5f;


    private int _currentStepChangeDirection = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        StartRun();
        InvokeRepeating("ChangeDirection", 0, _timeToChangeDirection);
    }

    public void StartRun()
    {
        _agent.enabled = true;
        _isRunning = true;
        SetDirection();
        _animator.SetBool("isRunning", _isRunning);
    }

    private void SetDirection()
    {
        _point = _points[Random.Range(0, _points.Count)];
        _agent.SetDestination(_point.position);
    }

    private IEnumerator GrabbedByPlayer()
    {
        _currentStepChangeDirection = 0;
        Player.instance.GrabPrisoner(this);
        yield return new WaitForSeconds(_timeToGrabbed);
        _agent.enabled = false;
        _isRunning = false;
        _meshRenderer.enabled = false;
        transform.SetParent(Player.instance.transform);
        _animator.SetBool("isRunning", _isRunning);
        Player.instance.ActivateNet();
    }

    public void SetInPrisonCell(PrisonCell cell)
    {
        _meshRenderer.enabled = true;
        transform.position = cell.transform.position;
        _agent.enabled=true;
    }

    private IEnumerator StartUnLockDoor(PrisonCellDoor door)
    {
        _agent.speed = 0;
        _animator.SetTrigger("StartUnlock");
        yield return new WaitForSeconds(_timeToUnlock);
        door.Open();
        _agent.speed = _speed;
    }

    private void ChangeDirection()
    {
        if(_currentStepChangeDirection < _countStepsChangeDirection && (_isRunning))
        {
            _currentStepChangeDirection++;
            SetDirection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_isRunning)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                if(!player.IsGrab)
                    StartCoroutine(GrabbedByPlayer());
            }
            else if (other.gameObject.TryGetComponent<UnLockCollider>(out UnLockCollider collider))
            {
                StartCoroutine(StartUnLockDoor(collider.Door));
            }
        }
    }
}
