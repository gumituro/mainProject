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
        Debug.Log("Enemy died!");
        anim.SetTrigger("death");
                AudioManager.instance.PlaySFX(8);


    }
    void OnDeathAnimationEnd()
    {
        Destroy(gameObject);
    }
}
