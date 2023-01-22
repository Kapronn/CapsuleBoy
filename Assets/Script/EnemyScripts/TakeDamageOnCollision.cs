using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int collisionDamage = 1;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.Hit(collisionDamage);
            }
        }
    }
}