using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void RestartLevel()
    {
        AdManager._adManagerInstance.ShowInterstitialAd();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    public void ReturnToMainMenu()
    {
        AdManager._adManagerInstance.ShowInterstitialAd();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
