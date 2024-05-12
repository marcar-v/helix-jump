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
        currentScoreText.text = "00000" + GameManager._gameManagerInstance.score;
        bestscoreText.text = "0000" + GameManager._gameManagerInstance.bestScore;
    }
}

