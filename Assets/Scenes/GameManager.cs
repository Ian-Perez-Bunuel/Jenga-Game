using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int enemyAmount;



    protected void Awake()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Set the enemy count to the number of enemies found
        enemyAmount = enemies.Length;

    }

    private void Update()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Set the enemy count to the number of enemies found
        enemyAmount = enemies.Length;

        if (enemyAmount <= 0)
        {
            SceneManager.LoadScene("jenga Area");

            //reset shots fired after each room
            PlayerPrefs.SetInt("Shots", 0);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
}