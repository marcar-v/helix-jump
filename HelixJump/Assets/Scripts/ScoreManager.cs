using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI bestscoreText;

    void Update()
    {
        currentScoreText.text = "" + GameManager._gameManagerInstance.score;
        bestscoreText.text = "" + GameManager._gameManagerInstance.bestScore;
    }
}

