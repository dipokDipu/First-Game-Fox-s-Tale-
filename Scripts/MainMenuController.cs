using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;

    public string sceneSelecter , sceneSelecter2;
    public GameObject continueGame;
    
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(sceneSelecter))
        {
            continueGame.SetActive(true);
        }
        else
        {
            continueGame.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(sceneSelecter);
        PlayerPrefs.DeleteAll();
        
    }

    public void Continue()
    {

        SceneManager.LoadScene(sceneSelecter2);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
