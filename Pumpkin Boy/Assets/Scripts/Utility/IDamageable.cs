using UnityEngine;

public interface IDamageable
{
    void TakeDamage(HitType hitType, int amount);
}