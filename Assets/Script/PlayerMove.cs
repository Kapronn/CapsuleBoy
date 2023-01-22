using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private Transform capsule;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float friction;
    [SerializeField] private bool grounded;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float squatIntensity = 5f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Squat();

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float speedMultiplier = 1f;
        if (grounded == false)
        {
            speedMultiplier = 0.2f;

            if (_rigidbody.velocity.x > maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0f;
            }

            if (_rigidbody.velocity.x < -maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0f;
            }
        }

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * moveSpeed * speedMultiplier, 0, 0,
            ForceMode.VelocityChange);
        if (grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                _rigidbody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
    }

    private void Squat()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || grounded == false)
        {
            capsule.localScale = Vector3.Lerp(capsule.localScale, new Vector3(1f, 0.5f, 1f),
                Time.deltaTime * squatIntensity);
        }
        else
        {
            capsule.localScale = Vector3.Lerp(capsule.localScale, new Vector3(1f, 1f, 1f),
                Time.deltaTime * squatIntensity);
        }
    }


    private void OnCollisionStay(Collision collisionInfo)
    {
        GroundedCheck(collisionInfo);
    }

    private void GroundedCheck(Collision collisionInfo)
    {
        for (int i = 0; i < collisionInfo.contactCount; i++)
        {
            float angle = Vector3.Angle(collisionInfo.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                grounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }

    
}