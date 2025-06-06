using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 2;
    // ArcherController archer; 

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy1 = collision.GetComponent<Enemy1Health>();
            if (enemy1 != null)
            {
                enemy1.TakeDamage(1); //i couldnt set it to attackDamage in archerController
            }
            
        }
        Destroy(gameObject);
    }
}
