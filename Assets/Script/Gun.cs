using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawn;
    [SerializeField] private AudioSource shotSFX;
    [SerializeField] private GameObject flash;
    [SerializeField] private float flashTimeExist = 0.14f;
    [SerializeField]  private float bulletSpeed = 10f;
    [SerializeField] private float shotPeriod = 0.5f;
    private float _timer;

    private void Start()
    {
        FleshOff();
    }

    void Update()
    {
        ShootingProcess();
        
    }

    private void ShootingProcess()
    {
        _timer += Time.deltaTime;
        if (_timer >= shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0;
                GameObject newBullet = Instantiate(bulletPrefab, spawn.position, spawn.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = spawn.forward * bulletSpeed;
                shotSFX.Play();
                FleshProcess();
            }
        }
    }

    void FleshProcess()
    {
        flash.SetActive(true);
        Invoke("FleshOff", flashTimeExist);
    }

    void FleshOff()
    {
        flash.SetActive(false);
    }
}