using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
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
        //"Fire1" is Mouse Button 1, auto done by unity
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public int shots;
    public int highestShots;
    public int timesClicked;

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

            //For Stats:
            //if the players score is higher than the highscore it will replace the highscore with that score
            shots = PlayerPrefs.GetInt("Shots");
            shots = shots + 1;
            PlayerPrefs.SetInt("Shots", shots);

            //check if the shots youve fired is higher than the last highest
            if (PlayerPrefs.GetInt("Shots") > PlayerPrefs.GetInt("HighestShots"))
            {
                PlayerPrefs.SetInt("HighestShots", shots);
            }
        }
        else
            //track how many times you clicked
            timesClicked = PlayerPrefs.GetInt("TimesClicked");
            timesClicked = timesClicked + 1;
            PlayerPrefs.SetInt("TimesClicked", timesClicked);
    }
}