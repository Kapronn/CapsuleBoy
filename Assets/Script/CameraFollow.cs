using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float lerpSpeed;

    void Update()
    {
        if (cameraTarget)
        {
            transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * lerpSpeed);
        }
    }
}