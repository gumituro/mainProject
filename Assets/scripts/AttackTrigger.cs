using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public bool enemyInRange = false;
    public GameObject currentEnemy = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = true;
            currentEnemy = other.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // if (other.gameObject == currentEnemy)
            
                enemyInRange = false;
                // currentEnemy = null;
            
        }
    }
}
