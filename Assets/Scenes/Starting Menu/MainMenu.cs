using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        //sets variables back to 0
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("BlockCounter", 0);
        PlayerPrefs.SetInt("TotalKills", 0);
        PlayerPrefs.SetInt("TimesHit", 0);
        PlayerPrefs.SetInt("HighestShots", 0);
        PlayerPrefs.SetInt("Shots", 0);
        PlayerPrefs.SetInt("TimesClicked", 0);
    }

    public Difficulty difficulty;
    public void PlayGame()
    {
        SceneManager.LoadScene("Jenga Area");
    }
}
