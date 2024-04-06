using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManagerInstance;

    [SerializeField] int _bestScore;
    public int bestScore {  get { return _bestScore; } set {  _bestScore = value; } }
    [SerializeField] int _score;
    public int score { get { return _score; } set { _score = value; } }

    [SerializeField] int currentLevel = 0;

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _actualLevelText;
    [SerializeField] TextMeshProUGUI _nextLevelText;

    [SerializeField] Transform _topTransform;
    [SerializeField] Transform _bottomTransform;
    [SerializeField] Transform _ballTransform;

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
    private void Update()
    {
        SliderProgress();
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

    public void SliderProgress()
    {
        _actualLevelText.text = "" + (currentLevel+ 1);
        _nextLevelText.text = "" + (currentLevel + 2);

        float _totalDistance = (_topTransform.position.y - _bottomTransform.position.y);
        float _distanceLeft = _totalDistance - (_ballTransform.position.y - _bottomTransform.position.y);
        float value = (_distanceLeft / _totalDistance);

       _slider.value = Mathf.Lerp(_slider.value, value, 5f);
    }
}
