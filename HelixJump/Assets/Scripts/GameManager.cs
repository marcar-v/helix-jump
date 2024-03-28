using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManagerInstance;

    [SerializeField] int _bestScore;
    public int bestScore {  get { return _bestScore; } set {  _bestScore = value; } }
    [SerializeField] int _score;
    public int score { get { return _score; } set { _score = value; } }

    [SerializeField] int currentLevel = 0;

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
        currentLevel++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentLevel);
        Debug.Log("Level completed");
    }

    public void RestartLevel()
    {
        _gameManagerInstance.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentLevel);

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
