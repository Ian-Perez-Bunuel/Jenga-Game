using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    //PlayerPrefs save data to unity between scenes/levels
    public int score;
    private int scoreAdded;
    private int dif;
    public int totalKills;


    public void Score()
    {
        dif = PlayerPrefs.GetInt("difficulty");
        //setting the damage to a different value depending on the difficulty
        if (dif == 1)
        {
            scoreAdded = 50;
        }

        if (dif == 2)
        {
            scoreAdded = 100;
        }

        if (dif == 3)
        {
            scoreAdded = 150;
        }

        //makes score = the PlayerPrefs of type "Score"
        score = PlayerPrefs.GetInt("Score");
        score = score + scoreAdded;
        PlayerPrefs.SetInt("Score", score);

        //get the total enemies defeated
        totalKills = PlayerPrefs.GetInt("TotalKills");
        //adds 1 everytime you kills something
        totalKills = totalKills + 1;
        PlayerPrefs.SetInt("TotalKills", totalKills);
    }



    public void Restart()
    {
        SceneManager.LoadScene("Starting Scene");
    }

    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }

}
