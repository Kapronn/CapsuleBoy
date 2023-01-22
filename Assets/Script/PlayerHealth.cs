
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Characteristics")] [SerializeField]
    private int playerHealth = 3;

    [SerializeField] private int playerMaxHealth = 5;
    [SerializeField] private float invulnerableAfterHit = 1f;

    [Header("SFX")] [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource healSound;

    private bool _invulnerable = false;
    private HealthUI _healthUI;
    private DamageImageScript _damageImageScript;
   [SerializeField] private UnityEvent eventOnTakeDamage;


    private void Start()
    {
        
        References();
        _healthUI.Setup(playerMaxHealth);
        _healthUI.HealthDisplay(playerHealth);
    }

    void References()
    {
        _damageImageScript = FindObjectOfType<DamageImageScript>();
        _healthUI = FindObjectOfType<HealthUI>();
    }
    public void TakeDamage(int damage)
    {
        if (_invulnerable == false)
        {
            playerHealth -= damage;
            if (playerHealth <= 0)
            {
                playerHealth = 0;
                DieProcess();
            }

            hitSound.Play();
            _healthUI.HealthDisplay(playerHealth);
            eventOnTakeDamage.Invoke();
            _damageImageScript.CallDamageVisualEffect();
            _invulnerable = true;
            Invoke("StopInvulnerable", invulnerableAfterHit);
        }
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue)
    {
        playerHealth += healthValue;
        healSound.Play();
        _healthUI.HealthDisplay(playerHealth);
        if (playerHealth >= playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }

    void DieProcess()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("SampleScene");
    }
}