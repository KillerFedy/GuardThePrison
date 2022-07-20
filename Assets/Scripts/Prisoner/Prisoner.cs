using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    [SerializeField]private SkinnedMeshRenderer _meshRenderer;

    [SerializeField] private float _timeToUnlock;
    
    private NavMeshAgent _agent;
    private Transform _point;
    private bool _isRunning = true;
    private Animator _animator;
    private float _speed = 3.5f;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        StartRun();
    }

    public void StartRun()
    {
        _agent.enabled = true;
        _isRunning = true;
        _point = _points[Random.Range(0, _points.Count)];
        _agent.SetDestination(_point.position);
        _animator.SetBool("isRunning", _isRunning);
    }

    private void GrabbedByPlayer()
    {
        _agent.enabled = false;
        _isRunning = false;
        _meshRenderer.enabled = false;
        transform.SetParent(Player.instance.transform);
        Player.instance.GrabPrisoner(this);
        _animator.SetBool("isRunning", _isRunning);
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

    private void OnTriggerEnter(Collider other)
    {
        if(_isRunning)
        {
            if (other.gameObject.TryGetComponent<Player>(out Player player))
            {
                GrabbedByPlayer();
            }
            else if (other.gameObject.TryGetComponent<UnLockCollider>(out UnLockCollider collider))
            {
                StartCoroutine(StartUnLockDoor(collider.Door));
            }
        }
    }
}
