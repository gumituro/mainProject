using UnityEngine;

public class Enemy2Health : MonoBehaviour
{
    public int health = 3;
    public Animator anim;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy2 took damage: " + damage + ", health left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
                AudioManager.instance.PlaySFX(7);

        anim.SetTrigger("death");
        Debug.Log("Enemy died!");

    }
    void OnDeathAnimationEnd()
    {
        Destroy(gameObject);

    }
}
