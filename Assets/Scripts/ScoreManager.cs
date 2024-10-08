using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    private int score = 0;
    private int savedScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void SetScoreText(TMP_Text newScoreText)
    {
        scoreText = newScoreText;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Pontos: " + score.ToString() + "/" + "800";
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        savedScore = 0;
        UpdateScoreText();
    }

    public void SaveScore()
    {
        savedScore = score;
    }

    public void RestoreScore()
    {
        score = savedScore;
        UpdateScoreText();
    }

    public void SetSavedScore(int value)
    {
        savedScore = value;
    }

    public void ResetScoreForNewLevel()
    {
        score = 0;
        UpdateScoreText();
    }
}









