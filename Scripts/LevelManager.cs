using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Vector3 respawnPosition;
    public float respawnDelay;

    public int gemCollected;
    public float timeTaken;

    public string nextLevel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeTaken = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeTaken += Time.deltaTime;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        PlayerHealthController.instance.gameObject.SetActive(false);
        //PlayerHealthController.instance.deactive.isTrigger = true;
        PlayerHealthController.instance.currentHealth = 0.00f;
        UiHandler.instance.displayHealth();
        AudioController.instance.playSound(8);

        yield return new WaitForSeconds(respawnDelay -(1f/UiHandler.instance.fadeSpeed));
        UiHandler.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UiHandler.instance.fadeSpeed) + .5f);
        UiHandler.instance.FadeFromBlack();

        //PlayerHealthController.instance.deactive.isTrigger = false;
        PlayerHealthController.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.transform.position = respawnPosition;
        PlayerHealthController.instance.sp.flipX = false;

        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UiHandler.instance.displayHealth();
    }

    public void LevelEnd()
    {
        this.enabled = false;
        StartCoroutine(LevelEndCo());
    }

    IEnumerator LevelEndCo()
    {
        AudioController.instance.VictoryMusic();
        PlayerController.instance.enabled = false;
        CameraMovement.instance.enabled = false;
        
        UiHandler.instance.levelComplete.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        UiHandler.instance.FadeToBlack();

        yield return new WaitForSeconds((1f/UiHandler.instance.fadeSpeed)+2.5f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);

        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_BestGem"))
        {
            if (gemCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_BestGem"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_BestGem", gemCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_BestGem", gemCollected);
        }

        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeTaken);
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_BestTime"))
        {
            if (timeTaken < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_BestTime"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_BestTime", timeTaken);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_BestTime", timeTaken);
        }

            SceneManager.LoadScene(nextLevel);
    }
}
