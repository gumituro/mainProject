using System;
using Unity.Mathematics;
using UnityEngine;

public class enemy2controler : MonoBehaviour
{
    public float fireRate = 1f; 
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    private float fireTimer = 0f;
    public Boolean ViewIsRight; 

    void Update()
    {
        if (DangerArea.instance.target != null)
        {

            if (ViewIsRight)
            {
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
    if (DangerArea.instance.target == null) return;

    Vector2 direction = (DangerArea.instance.target.position - firePoint.position).normalized;

    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    
    bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
}



}