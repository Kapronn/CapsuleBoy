using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletVFX;  
    void Start()
    {
        Destroy(gameObject, 5);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(bulletVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
