using UnityEngine;
using TMPro;

public class SceneSetup : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        if (ScoreManager.instance != null && scoreText != null)
        {
            ScoreManager.instance.SetScoreText(scoreText);
        }
    }
}

