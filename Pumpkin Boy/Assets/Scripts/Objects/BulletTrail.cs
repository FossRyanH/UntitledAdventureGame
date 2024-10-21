using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float _speed = 50f;

    public static event Action TriggerHit;
    
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
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isDestroyed)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            _isDestroyed = true;
        }
        TriggerHit?.Invoke();

        Debug.Log($"Hit {other.gameObject.name}");
    }
}
