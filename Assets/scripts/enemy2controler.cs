using UnityEngine;

public class enemy2controler : MonoBehaviour
{
    public float fireRate = 1f; 
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private Transform target;
    private float fireTimer = 0f;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);

            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    void Shoot()
    {
            Debug.Log("Shooting!");

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {       
             Debug.Log("Player is in range");

            target = other.transform;
        }
    }





    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.transform == target)
        {
            target = null;
        }
    }
}
