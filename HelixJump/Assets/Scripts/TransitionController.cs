using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    private Animator _transitionAnimator;
    [SerializeField] float _transitionTime;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _transitionAnimator = GetComponentInChildren<Animator>();
    }
    public void LoadNextScene()
    {
        int _nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(SceneLoad(_nextSceneIndex));
    }

    public IEnumerator SceneLoad(int sceneIndex)
    {
        //Trigger para reproducir efecto fade in
        _transitionAnimator.SetTrigger("Start");
        //Esperar un segundo
        yield return new WaitForSeconds(_transitionTime);
        //Cargar escena
        SceneManager.LoadScene(sceneIndex);
        _transitionAnimator.SetTrigger("End");
    }
}
