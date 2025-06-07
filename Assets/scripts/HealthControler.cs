using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthControler : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;

    private float damageCooldown = 1f;
    private float lastDamageTime;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // ذخیره مکان شروع
    }

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;
    }

    public void Damage()
    {
        if (Time.time - lastDamageTime >= damageCooldown)
        {
            currentHealth--;
            //UIcontroller.instance?.UpdateHealthDisplay(); // در صورت وجود
            lastDamageTime = Time.time;

            Debug.Log($"{gameObject.name} took damage. Current Health: {currentHealth}");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log($"{gameObject.name} died!");
                RespawnToStart();
            }
        }
    }

    public void RespawnToStart()
    {
        transform.position = startPosition;
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }
}