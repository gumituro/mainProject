using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float shootInterval = 1f;
    public float shootSpeed = 10f;

    private Transform currentTarget;
    private float shootTimer;

    private void Update()
    {
        if (currentTarget != null)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                ShootAtTarget();
                shootTimer = shootInterval;
            }
        }
    }

    private void ShootAtTarget()
    {
        Vector2 direction = (currentTarget.position - shootPoint.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * shootSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (currentTarget == null && other.CompareTag("Player"))
        {
            currentTarget = other.transform;
            shootTimer = 0f; // برای شلیک سریع بعد از ورود
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform == currentTarget)
        {
            currentTarget = null;
        }
    }
}
