using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float _speed = 50f;

    public static event HitEvent TriggerHit;

    public delegate void HitEvent(HitType hit, int amount);

    int _damageAmount;
    
    bool _isDestroyed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _speed * Time.fixedDeltaTime;
    }

    void Update()
    {
        if (_isDestroyed)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject, 3f);
        }
    }

    HitType GetHitType(GameObject objHit)
    {
        if (objHit.CompareTag("Player"))
        {
            return HitType.PlayerHit;
        }
        else if (objHit.CompareTag("Enemy"))
        {
            return HitType.EnemyHit;
        }
        else if (objHit.CompareTag("Boss"))
        {
            return HitType.BossHit;
        }
        else
        {
            return HitType.OtherHit;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) { return; }

        if (!_isDestroyed)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            _isDestroyed = true;
        }
        TriggerHit?.Invoke(GetHitType(other.gameObject), _damageAmount);
    }
}

public enum  HitType { PlayerHit, EnemyHit, BossHit, OtherHit }
