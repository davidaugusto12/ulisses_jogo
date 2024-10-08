using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;

    Damageable playerDamageable;
    // Start is called before the first frame update
    void Start()
    {
        
        healthSlider.value = CalculateSlidePercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarText.text = "HP" + playerDamageable.Health + "/" + playerDamageable.MaxHealth;
    }

    private void OnEnable ()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSlidePercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null)
        {
            Debug.Log("Sem player");
        }

        playerDamageable = player.GetComponent<Damageable>();
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth )
    {
        healthSlider.value = CalculateSlidePercentage(newHealth, maxHealth);
        healthBarText.text = "HP" + newHealth + "/" + maxHealth;
    }
}
