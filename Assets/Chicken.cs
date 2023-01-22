using UnityEngine;

public class Chicken : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _playerTransform;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeToReachSpeed = 1f;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Vector3 force = _rigidbody.mass * (toPlayer * speed - _rigidbody.velocity) / timeToReachSpeed;
        
        _rigidbody.AddForce(force);
    }
}
