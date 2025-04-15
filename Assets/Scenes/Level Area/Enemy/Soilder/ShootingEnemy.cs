using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{


    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    // this will be the time between each bullet shot
    public float fireRate;
    float nextFire;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        //checks if the fireRate allows another bullet to be shot
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // creating bullet (giving it all the information it will need)
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //getting the RigidBody of the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            //adding force to the bullet
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}