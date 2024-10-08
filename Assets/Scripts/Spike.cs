using UnityEngine;

public class Spike : MonoBehaviour
{
    // Evento que é chamado quando o espinho colide com o jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto que colidiu tem a tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Obtém o componente Damageable do jogador
            Damageable damageable = collision.GetComponent<Damageable>();

            // Se o componente Damageable existir, aplica dano e mata o jogador
            if (damageable != null)
            {
                damageable.Health = 0; // Define a saúde do jogador para 0
            }
        }
    }
}

