using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;

public class UIManager : MonoBehaviour
{
    [SerializeField] TransitionController _transitionController;

    public void PlayButton()
    {
        _transitionController.LoadNextScene();
    }

    public void QuitButton()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
