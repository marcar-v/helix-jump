using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody _rigigbody;
    [SerializeField] float _force = 3f;
    bool _ignoreNextCollision;
    float _delay = 0.2f;

    void Awake()
    {
        _rigigbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(_ignoreNextCollision)
        {
            return;
        }
        _rigigbody.velocity = Vector3.zero;
        _rigigbody.AddForce(Vector3.up * _force, ForceMode.Impulse);

        _ignoreNextCollision = true;

        Invoke("AllowNextCollision", _delay);
    }

    void AllowNextCollision()
    {
        _ignoreNextCollision = false;
    }
}
