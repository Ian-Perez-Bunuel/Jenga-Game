using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{

    public int bossAmount;




    protected void Awake()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        // Set the enemy count to the number of enemies found
        bossAmount = bosses.Length;

    }

    private void Update()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");

        // Set the boss count to the number of bosses found
        bossAmount = bosses.Length;

        if (bossAmount <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }


}