using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] BallController ballController;
    float _offset;
    void Start()
    {
        _offset = transform.position.y - ballController.transform.position.y;
    }

    void Update()
    {
        Vector3 _actualPosition = transform.position;
        _actualPosition.y = ballController.transform.position.y + _offset;
        transform.position = _actualPosition;
    }
}
