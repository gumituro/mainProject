using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("hit");

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("die");
        BossController.instance.BossDied();
    }
}