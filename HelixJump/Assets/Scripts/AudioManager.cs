using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _buttonSound;

    public static AudioManager _audioManagerInstance;
    // Start is called before the first frame update
    void Awake()
    {
        if(_audioManagerInstance == null)
        {
            _audioManagerInstance = this;
        }
        else if(_audioManagerInstance != this)
        {
            Destroy(gameObject);
        }
    }
    public void ButtonSound()
    {
        _buttonSound.Play();
    }
}
