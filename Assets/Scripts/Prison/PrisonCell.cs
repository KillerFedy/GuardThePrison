using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCell : MonoBehaviour
{
    private bool _isFull;

    public bool IsFull => _isFull;

    private void Start()
    {
        _isFull = false;
    }

    public void SetPrisoner(Prisoner prisoner)
    {
        _isFull = true;
        prisoner.SetInPrisonCell(this);
    }
}
