using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    public Image life1, life2, life3;
    public Sprite fullLife, halfLife, emptyLife;
    public static UiHandler instance;
    public Text gemCollectedText;

    public float fadeSpeed;
    private bool fadetoBlack, fadefromBlack;

    public Image darkScreen;

    public GameObject levelComplete;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadefromBlack)
        {
            darkScreen.color = new Color(darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, Mathf.MoveTowards(darkScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(darkScreen.color.a == 0f)
            {
                fadefromBlack = false;
            }
        }
        else if(fadetoBlack)
        {
                darkScreen.color = new Color(darkScreen.color.r, darkScreen.color.g, darkScreen.color.b, Mathf.MoveTowards(darkScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
                if (darkScreen.color.a == 1f)
                {
                    fadetoBlack = false;
                }
        }
    }

    public void displayHealth()
    {
        switch(PlayerHealthController.instance.currentHealth)
        {
            case 3.00f:
                life1.sprite = fullLife;
                life2.sprite = fullLife;
                life3.sprite = fullLife;
                break;

            case 2.50f:
                life1.sprite = fullLife;
                life2.sprite = fullLife;
                life3.sprite = halfLife;
                break;

            case 2.00f:
                life1.sprite = fullLife;
                life2.sprite = fullLife;
                life3.sprite = emptyLife;
                break;

            case 1.50f:
                life1.sprite = fullLife;
                life2.sprite = halfLife;
                life3.sprite = emptyLife;
                break;

            case 1.00f:
                life1.sprite = fullLife;
                life2.sprite = emptyLife;
                life3.sprite = emptyLife;
                break;

            case 0.50f:
                life1.sprite = halfLife;
                life2.sprite = emptyLife;
                life3.sprite = emptyLife;
                break;

            case 0.00f:
                life1.sprite = emptyLife;
                life2.sprite = emptyLife;
                life3.sprite = emptyLife;
                break;

            default:
                life1.sprite = emptyLife;
                life2.sprite = emptyLife;
                life3.sprite = emptyLife;
                break;
        }
    }

    public void gemText()
    {
        gemCollectedText.text = "x"+LevelManager.instance.gemCollected.ToString("000");
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
}
