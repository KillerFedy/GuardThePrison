using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prison : MonoBehaviour
{
    [SerializeField] private float _distanceToRunPrisoners;

    private PrisonCell[] _prisonCells;

    private void Start()
    {
        _prisonCells = GetComponentsInChildren<PrisonCell>();
    }

    private void Update()
    {
        if(GetDistancePlayer() > _distanceToRunPrisoners)
        {
            ReleasePrisoners();
        }
    }

    private void SetPrisonersInPrison(List<Prisoner> prisoners)
    {
        for(int i = 0; i < prisoners.Count; i++)
        {
            for(int j = 0; j < _prisonCells.Length; j++)
            {
                if(!_prisonCells[j].IsFull)
                {
                    _prisonCells[j].SetPrisoner(prisoners[i]);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if(player.Prisoners.Count > 0)
            {
                SetPrisonersInPrison(player.Prisoners);
                player.DropPrisoners();
            }
        }
    }

    private void ReleasePrisoners()
    {
        foreach (PrisonCell item in _prisonCells)
        {
            item.ReleasePrisoner();
        }
    }

    private float GetDistancePlayer()
    {
        return Vector3.Distance(transform.position, Player.instance.transform.position);
    }
}
