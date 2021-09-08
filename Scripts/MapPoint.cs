using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up,down,left,right;
    public bool isLevel;
    public string levelToLoad , levelToCheck;
    public bool isLocked;
    public string levelName;
    public int gemsCollected, bestGemsCollected ,totalGems;

    public GameObject timeBadge, gemBadge;
    //private float bestTimeInSeconds, lastTimeInSeconds;
    public float bestTime, lastTime;
    //public int lastTime_Minute, lastTime_Hour, bestTime_Minute, bestTime_Hour;
    //public float lastTime_Seconds, bestTime_Seconds;
    // Start is called before the first frame update
    void Start()
    {
        if(isLevel && levelToLoad!="")
        {
                isLocked = true;
                if (PlayerPrefs.HasKey(levelToCheck))
                {
                    if (PlayerPrefs.GetInt(levelToCheck) == 1)
                    {
                        isLocked = false;
                    }
                }

            if (PlayerPrefs.HasKey(levelToLoad+"_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");     
            }


            if (PlayerPrefs.HasKey(levelToLoad + "_BestGem"))
            {
                bestGemsCollected = PlayerPrefs.GetInt(levelToLoad + "_BestGem");
            }


            if (PlayerPrefs.HasKey(levelToLoad + "_time"))
            {

                lastTime = PlayerPrefs.GetFloat(levelToLoad + "_time");

                /*lastTimeInSeconds = PlayerPrefs.GetFloat(levelToLoad + "_time");

                lastTime_Minute = (int)(lastTimeInSeconds / 60);
                lastTime_Hour = lastTime_Minute / 60;
                lastTime_Seconds = lastTimeInSeconds - (lastTime_Minute * 60);*/
            }

            if (PlayerPrefs.HasKey(levelToLoad + "_BestTime"))
            {

                bestTime = PlayerPrefs.GetFloat(levelToLoad + "_BestTime");
                /*bestTimeInSeconds = PlayerPrefs.GetFloat(levelToLoad + "_bestTime");

                bestTime_Minute = lastTime_Minute;
                bestTime_Hour = lastTime_Hour;
                bestTime_Seconds = lastTime_Seconds;*/
            }

            if(isLevel && lastTime==bestTime && bestTime!=0f)
            {
                timeBadge.SetActive(true);
            }
            else
            {
                timeBadge.SetActive(false);
            }

            if (isLevel && bestGemsCollected==totalGems)
            {
                gemBadge.SetActive(true);
            }
            else
            {
                gemBadge.SetActive(false);
            }


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
