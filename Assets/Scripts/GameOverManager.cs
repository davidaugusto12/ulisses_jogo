using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button backToMenuButton;
    public float fadeDuration = 1f; // Duração do efeito de fade

    private CanvasGroup canvasGroup;
    private LevelManager levelManager;

    private void Start()
    {
        // Adiciona os ouvintes para os botões
        restartButton.onClick.AddListener(RestartGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
        
        canvasGroup = gameOverPanel.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameOverPanel.AddComponent<CanvasGroup>();
        }

        // Desativa o painel ao iniciar a fase
        gameOverPanel.SetActive(false);
        canvasGroup.alpha = 0f; // Começa invisível

        levelManager = FindObjectOfType<LevelManager>();
    }

    public void ShowGameOver()
    {
        Debug.Log("Showing Game Over Panel"); // Adiciona uma mensagem de log
        gameOverPanel.SetActive(true); // Ativa o painel
        StartCoroutine(FadeIn());
        Time.timeScale = 0f; // Pausa o jogo
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Despausa o jogo
        RestartLevel();
    }

    public void RestartLevel()
    {
        // Restaura a pontuação salva ao reiniciar a fase
        ScoreManager.instance.RestoreScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        // Chama o método para carregar a próxima fase
        if (levelManager != null)
        {
            levelManager.LoadNextLevel();
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; // Despausa o jogo
        SceneManager.LoadScene("Menu");
    }
}









