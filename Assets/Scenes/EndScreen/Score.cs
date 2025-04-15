using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public EndSceneManager scoreManager;

    //reference to both your score and the highscore texts
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI totalKills;
    public TextMeshProUGUI hitAmount;
    public TextMeshProUGUI hShotsFired;
    public TextMeshProUGUI ShotsFiredMinusClicks;
    public TextMeshProUGUI BlocksTaken;

    public int score;
    public int bigScore;
    public int TKills;
    public int timesHit;
    public int hFiredShots;
    public int blocksTaken;
    //variables for the difference in clicks and shots fired
    public int clicks;
    public int FiredShots;
    public int shotsFiredMinusClicks;




    private void Start()
    {
        //set different variables to their coresponding values
        score = PlayerPrefs.GetInt("Score");
        bigScore = PlayerPrefs.GetInt("HighScore");
        TKills = PlayerPrefs.GetInt("TotalKills");
        timesHit = PlayerPrefs.GetInt("TimesHit");
        hFiredShots = PlayerPrefs.GetInt("HighestShots");
        blocksTaken = PlayerPrefs.GetInt("BlockCounter");
        // info for clicks - shots to see how many shots you couldve shot if you didnt have a shoot cooldown
        FiredShots = PlayerPrefs.GetInt("Shots");
        clicks = PlayerPrefs.GetInt("TimesClicked");

        shotsFiredMinusClicks = clicks - FiredShots;




        //set the highscore text to the highscore
        highScore.text = bigScore.ToString();
        totalKills.text = TKills.ToString();
        hitAmount.text = timesHit.ToString();
        hShotsFired.text = hFiredShots.ToString();
        ShotsFiredMinusClicks.text = shotsFiredMinusClicks.ToString();
        BlocksTaken.text = blocksTaken.ToString();
    }

    public void Update()
    {
        //if the players score is higher than the highscore it will replace the highscore with that score
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        //set your score to the score text
        scoreText.text = score.ToString();
    }
}
