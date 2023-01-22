using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform headTarget;

    private void Update()
    {
        transform.position = headTarget.position;
    }
}