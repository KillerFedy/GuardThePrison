using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonCellDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _timeToClose;

    public void Open()
    {
        _animator.SetBool("isOpened", true);
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(_timeToClose);
        _animator.SetBool("isOpened", false);
    }
}
