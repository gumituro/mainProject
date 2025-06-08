using System;
using Unity.Mathematics;
using UnityEngine;

public class enemy2controler : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public dangerArea dangerArea;

    // private Transform target;
    private float fireTimer = 0f;
    public Boolean ViewIsRight;
    // Animator anim; 

    void Update()
    {

        if (dangerArea.instance.target != null)
        {

            if (ViewIsRight)
            {
                // gameObject.transform.rotation.y = 180f; 
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
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
                AudioManager.instance.PlaySFX(1);


        Vector2 direction = (dangerArea.instance.target.transform.position - firePoint.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;

       
    }

}
