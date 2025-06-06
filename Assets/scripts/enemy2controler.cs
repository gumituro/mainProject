using System;
using Unity.Mathematics;
using UnityEngine;

public class enemy2controler : MonoBehaviour
{
    public float fireRate = 1f; 
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private Transform target;
    private float fireTimer = 0f;
    public Boolean ViewIsRight; 

    void Update()
    {
        if (target != null)
        {

            if (ViewIsRight)
            {
                // gameObject.transform.rotation.y = 180f; 
                transform.rotation = Quaternion.Euler(0 , 180f , 0); 
            }         

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
            if (other.transform.position.x > gameObject.transform.position.x)
            {
                ViewIsRight = true;
            }
            else
            {
                ViewIsRight = false; 
            }

            //  Debug.Log("Player is in range");

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
