using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject uiPanel; // Referência ao painel de UI

    private void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false); // Desativa o painel no início
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Ativar o painel de UI
            if (uiPanel != null)
            {
                uiPanel.SetActive(true);
            }
        }
    }
}





