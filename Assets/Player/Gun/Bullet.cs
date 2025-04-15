using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

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
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }

    }


}