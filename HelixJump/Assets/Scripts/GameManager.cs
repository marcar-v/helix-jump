using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManagerInstance;

    private int _bestScore;
    public int bestScore {  get { return _bestScore; } set {  _bestScore = value; } }

    private  int _score;
    public int score { get { return _score; } set { _score = value; } }

    private int _currentLevel = 0;
    public int currentLevel { get { return _currentLevel; } set { _currentLevel = value; } }
    
    [SerializeField] AudioSource _levelCompletedSound;

    [Header("GameOver Settings")]
    [SerializeField] GameObject _gameOverCanvas;

    void Awake()
    {
        if(_gameManagerInstance == null)
        {
            _gameManagerInstance = this;
        }
        else if(_gameManagerInstance != this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        _levelCompletedSound.Play();

        currentLevel++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
    }

    public void GameOver()
    {
        score = 0;
        Time.timeScale = 0;
        _gameOverCanvas.SetActive(true);
        //FindObjectOfType<HelixController>().LoadStage(currentLevel);
        //FindObjectOfType<BallController>().ResetBall();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
