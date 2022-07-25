using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _offset;

    private float _cameraSpeed = 5f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _offset, _cameraSpeed * Time.deltaTime);
    }
}
