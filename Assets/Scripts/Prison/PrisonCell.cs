using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCell : MonoBehaviour
{
    private PrisonCellDoor _door;

    private Prisoner _prisoner;

    public bool IsFull => _prisoner != null;

    private void Awake()
    {
        _door = GetComponentInChildren<PrisonCellDoor>();
    }

    public void SetPrisoner(Prisoner prisoner)
    {
        _prisoner = prisoner;
        prisoner.SetInPrisonCell(this);
        _door.Close();
    }

    public void ReleasePrisoner()
    {
        if (_prisoner != null)
        {
            _prisoner.StartRun();
            _prisoner = null;
        }
    }
}
