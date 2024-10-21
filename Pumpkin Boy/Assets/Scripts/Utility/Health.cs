using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; set; }
    [field: SerializeField] public int MaxHealth { get; private set; } = 100;

    public event Action CharacterDeath;

    void Awake()
    {
        BulletTrail.TriggerHit += TakeDamage;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(HitType hitType, int amount)
    {
        if (hitType == HitType.EnemyHit)
        {
            amount = 10;
            CurrentHealth -= amount * 100;
        }
        else if (hitType == HitType.PlayerHit)
        {
            amount = 5;
            CurrentHealth -= amount;
        }
        else if (hitType == HitType.BossHit)
        {
            amount = 10;
            CurrentHealth -= amount;
        }
        else
        {
            return;
        }

        if (CurrentHealth <= 0)
        {
            CharacterDeath?.Invoke();
        }
    }
}
