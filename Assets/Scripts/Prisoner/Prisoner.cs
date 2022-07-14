using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    private NavMeshAgent _agent;
    private Transform _point;
    private bool _isWaitingToRun = false;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _point = _points[Random.Range(0, _points.Count)];
    }

    private void Update()
    {
        if(!_isWaitingToRun)
            _agent.SetDestination(_point.position);
    }

    public void StartRun()
    {
        _point = _points[Random.Range(0, _points.Count)];
        _isWaitingToRun = false;
    }

    public void SetPrisonerWait()
    {
        _isWaitingToRun = true;
    }
}
