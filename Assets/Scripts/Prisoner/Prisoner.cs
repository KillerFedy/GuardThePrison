using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    [SerializeField] private GameObject _pointsParent;
    private Transform[] _points;
    private NavMeshAgent _agent;
    private Transform _point;
    private void Start()
    {
        _points = _pointsParent.GetComponentsInChildren<Transform>();
        _agent = GetComponent<NavMeshAgent>();
        _point = _points[Random.Range(0, _points.Length)];
    }

    private void Update()
    {
        _agent.SetDestination(_point.position);
    }
}
