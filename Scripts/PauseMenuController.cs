using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{
    public string levelSelect, mainMenu;

    public GameObject PauseScreen;
    public static PauseMenuController instance;
    public GameObject pauseSelectLevel;
    public string first_level;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PauseScreen.SetActive(false);

        /*if(!PlayerPrefs.HasKey(MainMenuController.instance.sceneSelecter))
        {
            pauseSelectLevel.SetActive(false);
        }
        else
        {
            pauseSelectLevel.SetActive(true);
        }*/

        if (!PlayerPrefs.HasKey(first_level))
        {
            pauseSelectLevel.SetActive(false);
        }
        else
        {
            pauseSelectLevel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();

        }
    }
    public void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        PlayerController.instance.enabled = false;
    }

    public void Unpause()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        PlayerController.instance.enabled = true;
    }

    public void LevelSelect()
    {
            PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(levelSelect);
            Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
