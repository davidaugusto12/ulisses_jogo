using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject portal; 
    public GameObject blocker;
    private Damageable damageable;

    private void Start()
    {
        // Desativar o portal no início
        if (portal != null)
        {
            portal.SetActive(false);
            Debug.Log("Portal desativado no início");
        }
        if (blocker != null)
        {
            blocker.SetActive(true);  // Ativa o bloqueador no início
            Debug.Log("Bloqueador ativado no início");
        }

        // Obter referência ao script Damageable
        damageable = GetComponent<Damageable>();
        if (damageable != null)
        {
            damageable.onDeath.AddListener(Defeated);
        }
    }

    private void Defeated()
    {
        Debug.Log("Boss derrotado");
        // Ative o portal ao derrotar o Boss
        if (portal != null)
        {
            portal.SetActive(true);
            Debug.Log("Portal ativado");
        }
        if (blocker != null)
        {
            blocker.SetActive(false);  // Desativa o bloqueador ao derrotar o Boss
            Debug.Log("Bloqueador desativado");
        }
    }
}













