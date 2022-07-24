using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Prison _prison;

    private void Update()
    {
        transform.LookAt(_prison.transform.position);
    }
}
