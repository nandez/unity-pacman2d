using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text txtScore;

    public static int HighScore { get; private set; }

    void Start()
    {
        UpdateHighScoreText();
    }

    public void AddPoints(int points)
    {
        HighScore += points;
        UpdateHighScoreText();
    }

    protected void UpdateHighScoreText()
    {
        txtScore.text = $"SCORE: {HighScore}";
    }
}
