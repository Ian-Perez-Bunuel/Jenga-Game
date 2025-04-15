using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkBlocks : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //if a certain amount of blocks have been taken it will send you to the boss level
        if (PlayerPrefs.GetInt("BlockCounter") == 8)
        {
            SceneManager.LoadScene("Boss Level");
        }
    }
}
