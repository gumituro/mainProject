using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HealthControler : MonoBehaviour
{
    public static HealthControler instance;
    public float maxHealth;
    public float currentHealth;

    private float damageCooldown = 1f; // زمان بین دو دمج
    private float lastDamageTime;

    void Start()
    {
        instance = this;
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;
    }

    // Update is called once per frame
    public void Damage()
    {

        if (Time.time - lastDamageTime >= damageCooldown)
        {
            currentHealth--;
            UIcontroller.instance.UpdateHealthDisplay();
            lastDamageTime = Time.time;

            Debug.Log("Player took damage. Current Health: " + currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Debug.Log("Player Died!"); //dead anim isnt applied
                StartCoroutine(RestartScene()); 

            }
        }
    }
    void Update()
    {

    }
    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(10 * Time.deltaTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    }

