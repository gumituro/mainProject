using UnityEngine;

public class ReturnPlayer : MonoBehaviour
{
    public Transform boundaryPoint; 
    public int damage = 1; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            if (other.GetComponent<ArcherHealth>() != null)
            {
                ArcherHealth archer = other.GetComponent<ArcherHealth>();
                archer.Damage();
                archer.ArchercurrentHealth -= damage;
            }
            else if (other.GetComponent<SwordsmanHealth>() != null)
            {
                SwordsmanHealth sword = other.GetComponent<SwordsmanHealth>();
                sword.Damage();
                sword.SwordscurrentHealth -= damage;
            }

            other.transform.position = boundaryPoint.position;
            
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}