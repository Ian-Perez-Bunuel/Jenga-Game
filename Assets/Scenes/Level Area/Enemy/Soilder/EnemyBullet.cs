using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerHealth playerHealth;

    public GameObject hitEffect;

    //reference to Difficulty script from the main menu
    Difficulty difficulty;
    //change in damage depending of difficulty
    public int dmgChange;
    public int modDmg;
    private int dif;
    public int damage = 1;


    private void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();


        //setting the damage to a different value depending on the difficulty
        if (dif == 1)
        {
            dmgChange = 0;
        }

        if (dif == 2)
        {
            dmgChange = 1;
        }

        if (dif == 3)
        {
            dmgChange = 2;
        }
    }

    private void Update()
    {
        //set the modified damage
        modDmg = dmgChange + damage;
    }

    //checks if bullet collided
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when the bullet collides it will at the "hitEffect" on that position
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //remove effect after 5 seconds
        Destroy(effect, 1f);
        //destroy bullet
        Destroy(gameObject);

        // Tell Enemys to take damage
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth enemyComponent))
        {
            enemyComponent.TakeDamage(modDmg);
        }
    }
}