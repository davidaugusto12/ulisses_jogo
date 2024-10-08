using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public Text scoreText;

    private void Start()
    {
        menuPanel.SetActive(false); // Garante que o menu esteja desativado no início
    }

    public void ShowMenu(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        menuPanel.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
    }

    public void HideMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f; // Retoma o jogo
    }

    public void ContinueGame()
    {
        HideMenu();
    }

    public void ReturnToLobby()
    {
        HideMenu();
        SceneManager.LoadScene("Menu"); // Substitua "Lobby" pelo nome da cena do lobby
    }
}

