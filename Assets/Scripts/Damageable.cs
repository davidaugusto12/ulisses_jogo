using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    private int _maxHealth = 100;

    public int MaxHealth 
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    [SerializeField]
    private int _health = 100;

    public int Health
    {
        get { return _health; }
        set 
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);
            if (_health <= 0)
            {
                IsAlive = false;
                OnDeath();
            }
        }
    }

    [Header("State Settings")]
    [SerializeField]
    private bool _isAlive = true;

    public bool IsAlive
    {
        get { return _isAlive; }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set: " + value);
            if (!value)
            {
                onDeath.Invoke();
            }
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    [SerializeField]
    private bool isInvincible = false;

    public bool IsInvincible
    {
        get { return isInvincible; }
        private set { isInvincible = value; }
    }

    [SerializeField]
    private float invincibilityTime = 0.25f;

    public float InvincibilityTime
    {
        get { return invincibilityTime; }
        set { invincibilityTime = value; }
    }

    [Header("Events")]
    public UnityEvent<int, Vector2> damageableHit;
    public UnityEvent onDeath = new UnityEvent();
    public UnityEvent<int, int> healthChanged;

    private float timeSinceHit = 0;
    private Animator animator;
    private GameOverManager gameOverManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            animator.SetBool(AnimationStrings.lockVelocity, true);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            return true;
        }

        return false;
    }

    public bool Heal(int healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
            int maxHealth = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHealth, healthRestore);
            Health += actualHeal;
            CharacterEvents.characterHealed(gameObject, actualHeal);
            return true;
        }

        return false;
    }

    private void OnDeath()
    {
        Debug.Log("OnDeath invoked");
        if (gameObject.CompareTag("Player") && gameOverManager != null)
        {
            gameOverManager.ShowGameOver();
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            ScoreManager.instance.AddScore(100); 
        }
        else if (gameObject.CompareTag("Boss")) 
        {
            ScoreManager.instance.AddScore(500); 
        }
        onDeath?.Invoke(); 
    }
}


