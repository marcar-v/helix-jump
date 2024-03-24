using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 _lastTapPosition;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.localEulerAngles;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 _currentTapPosition = Input.mousePosition;
            if(_lastTapPosition == Vector2.zero)
            {
                _lastTapPosition = _currentTapPosition;
            }

            float _distance = _lastTapPosition.x - _currentTapPosition.x;

            _lastTapPosition = _currentTapPosition;

            transform.Rotate(Vector3.up * _distance);
        }

        if(Input.GetMouseButtonUp(0))
        {
            _lastTapPosition = Vector2.zero;
        }
    }
}
