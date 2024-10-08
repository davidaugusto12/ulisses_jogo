using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 10;
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0);

    AudioSource pickupSource;

    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
            // Verifica se o jogador precisa de cura
            if (damageable.Health < damageable.MaxHealth)
            {
                bool wasHealed = damageable.Heal(healthRestore);

                if (wasHealed)
                {
                    if (pickupSource)
                        AudioSource.PlayClipAtPoint(pickupSource.clip, transform.position, pickupSource.volume);

                    Destroy(gameObject);
                }
            }
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }
}

