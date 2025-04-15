using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarChartBar : MonoBehaviour
{

    public Slider slider;

    public int totalKills;
    public int timesHit;
    public int highestShots;
    public int blocksCounter;

    private void Start()
    {
        //give each PlayerPrefs its own variable
        totalKills = PlayerPrefs.GetInt("TotalKills");
        timesHit = PlayerPrefs.GetInt("TimesHit");
        highestShots = PlayerPrefs.GetInt("HighestShots");
        blocksCounter = PlayerPrefs.GetInt("BlockCounter");

        //set the bars slider's max hight
        slider.maxValue = 50;

        //set each bars hights depending on their names
        if (slider.name == "TotalKillsBar")
        {
            slider.value = totalKills;
        }
        if (slider.name == "TimesHitBar")
        {
            slider.value = timesHit;
        }
        if (slider.name == "HighestShotsBar")
        {
            slider.value = highestShots;
        }
        if (slider.name == "BlocksTakenBar")
        {
            slider.value = blocksCounter;
        }

    }

}
