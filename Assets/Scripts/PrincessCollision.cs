using UnityEngine;

public class PrincessCollision : MonoBehaviour
{
    public int pointsForPlayer = 400; // Pontos a serem dados ao jogador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto com o qual colidiu é o jogador
        {
            // Adiciona os pontos ao ScoreManager
            ScoreManager.instance.AddScore(pointsForPlayer);

            // Opcional: você pode adicionar um efeito visual ou de áudio aqui

            // Destroi a princesa ou desativa o objeto
            Destroy(gameObject); // Destrói o objeto da princesa após a colisão
        }
    }
}

