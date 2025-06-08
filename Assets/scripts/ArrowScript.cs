using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 2;
    public ArcherController archer; 
    // ArcherController archer; 

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("enemy!!!");
            var enemy1 = collision.GetComponent<Enemy1Health>();
            var enemy2 = collision.GetComponent<Enemy2Health>();

            if (enemy1 != null)
            {
                enemy1.TakeDamage(1); //i couldnt set it to attackDamage in archerController
            }
            if (enemy2 != null)
            {
                enemy2.TakeDamage(1);
            }
            
        }
        Destroy(gameObject);
    }
}
