using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Prisoner : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private MeshRenderer _meshRenderer;
    private NavMeshAgent _agent;
    private Transform _point;
    private bool _isRunning = true;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _agent = GetComponent<NavMeshAgent>();
        _point = _points[Random.Range(0, _points.Count)];
    }

    private void Update()
    {
        if (_isRunning)
            _agent.SetDestination(_point.position);
        else
            _agent.SetDestination(_agent.transform.position);
    }

    public void StartRun()
    {
        _point = _points[Random.Range(0, _points.Count)];
        _isRunning = true;
    }

    private void GrabbedByPlayer()
    {
        _isRunning = false;
        _meshRenderer.enabled = false;
        transform.SetParent(Player.instance.transform);
    }

    public void SetPrisonerWait()
    {
        _isRunning = false;
    }

    public void SetInPrisonCell(PrisonCell cell)
    {
        _meshRenderer.enabled = true;
        transform.position = cell.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            GrabbedByPlayer();
            player.GrabPrisoner(this);
        }
    }
}
