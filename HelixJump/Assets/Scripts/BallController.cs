using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Collisions")]
    Rigidbody _rigigbody;
    [SerializeField] float _force = 3f;
    bool _ignoreNextCollision;
    float _delay = 0.2f;

    private Vector3 _startPosition;

    [Header("SuperSpeed")]
    private int _perfectPass;
    [SerializeField] float _superSpeed;
    bool _isSuperSpeedActive;
    int _perfectPassCount = 3;

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

        if(_isSuperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject, 0.2f);
        }

        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                Debug.Log("Death part");
                GameManager._gameManagerInstance.RestartLevel();
            }
        }

        _rigigbody.velocity = Vector3.zero;
        _rigigbody.AddForce(Vector3.up * _force, ForceMode.Impulse);

        _ignoreNextCollision = true;

        Invoke("AllowNextCollision", _delay);

        _perfectPass = 0;
        _isSuperSpeedActive = false;

        AudioManager._audioManagerInstance.BounceSound();
    }

    private void Update()
    {
        if(_perfectPass >= _perfectPassCount && !_isSuperSpeedActive)
        {
            _isSuperSpeedActive = true;

            _rigigbody.AddForce(Vector3.down * _superSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager._gameManagerInstance.AddScore(1);
        _perfectPass++;
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
