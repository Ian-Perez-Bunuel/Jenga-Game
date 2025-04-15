using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{

    public int difLevel;

    public void DifficultyH()
    {
        PlayerPrefs.SetInt("difficulty", 3);
    }

    public void DifficultyM()
    {
        PlayerPrefs.SetInt("difficulty", 2);
    }

    public void DifficultyE()
    {
        PlayerPrefs.SetInt("difficulty", 1);
    }
}
