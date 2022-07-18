using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCell : MonoBehaviour
{
    private Prisoner _prisoner;

    public bool IsFull => _prisoner != null;

    public void SetPrisoner(Prisoner prisoner)
    {
        _prisoner = prisoner;
        prisoner.SetInPrisonCell(this);
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
