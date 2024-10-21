using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float _speed = 50f;

    public event Action OnHit;
    
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
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this.gameObject, 3f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isDestroyed)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            _isDestroyed = true;
        }

        Debug.Log($"Hit {other.gameObject.name}");
    }
}
