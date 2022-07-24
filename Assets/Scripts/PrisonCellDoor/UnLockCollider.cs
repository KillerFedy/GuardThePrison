using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockCollider : MonoBehaviour
{
    [SerializeField] private PrisonCellDoor _door;

    public PrisonCellDoor Door => _door;
}
