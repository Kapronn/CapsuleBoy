using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private UnityEvent evenTakeDamage;
   public void Hit(int damage)
    {
        health -= damage;
        evenTakeDamage.Invoke();
        if (health <= 0)
        {
            Die();
        }
        
    }
   private void Die()
    {
        Destroy(gameObject);
    }
}
