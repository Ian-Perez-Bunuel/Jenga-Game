using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerBullet : MonoBehaviour
{
    public GameObject hitEffect;

    PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when the bullet collides it will at the "hitEffect" on that position
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //remove effect after 5 seconds
        Destroy(effect, 1f);

        // Tell Player to take damage and destroy the arm
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
