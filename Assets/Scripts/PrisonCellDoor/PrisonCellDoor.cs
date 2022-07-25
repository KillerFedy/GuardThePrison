using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCellDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        Open();
    }

    public void Open()
    {
        _animator.SetBool("isOpened", true);
    }

    public void Close()
    {
        _animator.SetBool("isOpened", false);
    }
}
