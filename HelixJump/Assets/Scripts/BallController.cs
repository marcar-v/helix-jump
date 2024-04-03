using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody _rigigbody;
    [SerializeField] float _force = 3f;
    bool _ignoreNextCollision;
    float _delay = 0.2f;

    private Vector3 _startPosition;
    void Awake()
    {
        _rigigbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _startPosition = transform.position;
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

        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if(deathPart)
        {
            Debug.Log("Death part");
            GameManager._gameManagerInstance.RestartLevel();
        }

        AudioManager._audioManagerInstance.BounceSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager._gameManagerInstance.AddScore(1);
    }

    void AllowNextCollision()
    {
        _ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
    }
}
