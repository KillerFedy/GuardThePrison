using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCell : MonoBehaviour
{
    private Prisoner _prisoner;

    private bool _isFull;

    public bool IsFull => _isFull;

    private void Start()
    {
        _isFull = false;
    }

    public void SetPrisoner(Prisoner prisoner)
    {
        _isFull = true;
        _prisoner = prisoner;
        prisoner.SetInPrisonCell(this);
    }

    public void ReleasePrisoner()
    {
        if (_prisoner != null)
            _prisoner.StartRun();
        _prisoner=null;
    }
}
