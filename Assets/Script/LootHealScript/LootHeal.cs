using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int addHealth = 1;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(addHealth);
            Destroy(gameObject);
        }
    }
}
