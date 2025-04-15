using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EndSceneManager scoreManager;

    //reference to Difficulty script from the main menu
    Difficulty difficulty;
    //change in damage depending of difficulty
    public int dmgChange;
    public int modDmg;
    private int dif;


    //reference for player health
    PlayerHealth playerHealth;

    //amount of damage enemy will deal
    public int damage = 1;
    //check if enemy can damage Player
    public bool canDamage;
    //check if when the enemy collides if it will kill them
    public bool DestroyOnCollide;

    public static event Action<Enemy> OnEnemyKilled;

    [SerializeField] float health, maxHealth = 3f;




    private void Start()
    {
        dif = PlayerPrefs.GetInt("difficulty");

        //set health to maxhealth on start
        health = maxHealth;

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



    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //3 -> 2 -> 1 -> 0, is what we want

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
            scoreManager.Score();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDamage)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerHealth.TakeDamage(modDmg);

                if (DestroyOnCollide == true)
                {
                    //kill enemy
                    Destroy(gameObject);
                    scoreManager.Score();
                }
            }
        }

    }
}