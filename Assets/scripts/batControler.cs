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

        Vector2 direction = (currentTarget.position - shootPoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shootPoint.rotation = Quaternion.Euler(0, 0, angle);
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
        Debug.Log("Trigger Entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range");
            currentTarget = other.transform;
            shootTimer = 0f;
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
