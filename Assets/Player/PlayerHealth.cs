using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public GameManager gameManager;
    public BossManager bossManager;

    public int currentHealth;
    public int maxHealth = 3;

    //used to save the damage taken
    public int timesHit;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //For health bar UI (sets the max health onto the UI)
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //Health bar updating its values
        healthBar.SetHealth(currentHealth);


        //makes damageTaken = the PlayerPrefs of type "DamageTaken"
        timesHit = PlayerPrefs.GetInt("TimesHit");
        //adds one damage taken whenever this function is run
        timesHit = timesHit + 1;
        //chaneg the PlayerPrefs to the int stored in damageTaken
        PlayerPrefs.SetInt("TimesHit", timesHit);


        if (currentHealth <= 0)
        {
            //checking scene info:
            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string sceneName = currentScene.name;

            if (sceneName == "Boss Level")
            {
                bossManager.GameOver();
            }
            else
                gameManager.GameOver();
        }
    }
}
