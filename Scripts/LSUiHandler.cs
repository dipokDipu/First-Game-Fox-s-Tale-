using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LSUiHandler : MonoBehaviour
{

    public static LSUiHandler instance;
    public float fadeSpeed;
    private bool fadetoBlack, fadefromBlack;
    public Image darkScreen;
    public GameObject levelPanel;
    public Text levelName;
    public Text gemsCollected, bestGemsCollected, lastTime, bestTime;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (fadefromBlack)
        {
            darkScreen.color = new Color(darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, Mathf.MoveTowards(darkScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (darkScreen.color.a == 0f)
            {
                fadefromBlack = false;
            }
        }
        else if (fadetoBlack)
        {
            darkScreen.color = new Color(darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, Mathf.MoveTowards(darkScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (darkScreen.color.a == 1f)
            {
                fadetoBlack = false;
            }
        }
    }
    public void FadeToBlack()
    {

        fadetoBlack = true;
        fadefromBlack = false;
    }

    public void FadeFromBlack()
    {

        fadetoBlack = false;
        fadefromBlack = true;
    }

    public void ShowLevelInfo(MapPoint position)
    {
        levelPanel.gameObject.SetActive(true);
        levelName.text = position.levelName;
        gemsCollected.text = "Last Collected Gems: "+position.gemsCollected.ToString("00")+"/"+position.totalGems.ToString("00");
        bestGemsCollected.text = "Best Collected Gems: " + position.bestGemsCollected.ToString("00") + "/" + position.totalGems.ToString("00");

        lastTime.text = "Last Time: " + position.lastTime.ToString("F2");
        bestTime.text = "Best Time: " + position.bestTime.ToString("F2");

        //lastTime.text = "Last Time: " + position.lastTime_Hour.ToString("00:") + position.lastTime_Minute.ToString("00:") + position.lastTime_Seconds.ToString("00.00");
        //bestTime.text = "Best Time: " + position.bestTime_Hour.ToString("00:") + position.bestTime_Minute.ToString("00:") + position.bestTime_Seconds.ToString("00.00");

    }

    public void HideLevelInfo()
    {
        levelPanel.gameObject.SetActive(false);
    }
}
