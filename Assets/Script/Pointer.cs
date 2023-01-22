using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform aim;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform bodyTransform;
    private float _yEuler;

    void Start()
    {
    }


    void Update()
    {
        TakeAim();
    }

    private void TakeAim()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        Debug.DrawRay(ray.origin, ray.direction * 15f, Color.red);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);
        aim.position = point;

        Vector3 toAim = aim.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);

        RotateBodyToAim(toAim);
    }

    private void RotateBodyToAim(Vector3 toAim)
    {
        if (toAim.x < 0)
        {
            _yEuler = Mathf.Lerp(_yEuler, 45f, Time.deltaTime * 8);
        }
        else
        {
            _yEuler = Mathf.Lerp(_yEuler, -45f, Time.deltaTime * 8);
        }

        bodyTransform.localEulerAngles = new Vector3(0, _yEuler, 0);
    }
}