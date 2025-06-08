using UnityEngine;

public class Enemy1Health : MonoBehaviour
{
    public int health = 3;
    public Animator anim; 

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy1 took damage: " + damage + ", health left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("death");
        AudioManager.instance.PlaySFX(8);

        Debug.Log("Enemy died!");
    }
    void deathAnim()
    {
        Destroy(gameObject);
    }
}
