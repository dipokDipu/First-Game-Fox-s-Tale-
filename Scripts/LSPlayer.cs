using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSPlayer : MonoBehaviour
{
    public LSPlayer instance;
    public MapPoint currentPosition;
    public float moveSpeed;
    public MapPoint[] allPoints;

    public LSUiHandler UI;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        allPoints = FindObjectsOfType<MapPoint>();
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            foreach (MapPoint point in allPoints)
            {
                if (point.levelToLoad == PlayerPrefs.GetString("CurrentLevel"))
                {
                    transform.position = point.transform.position;
                    ChangePosition(point);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPosition.transform.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, currentPosition.transform.position) < .1f)
        {


            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPosition.right != null)
                {
                    ChangePosition(currentPosition.right);
                }
            }

            else if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPosition.left != null)
                {
                    ChangePosition(currentPosition.left);
                }
            }


            else if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPosition.up != null)
                {
                    ChangePosition(currentPosition.up);
                }
            }

            else if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPosition.down != null)
                {
                    ChangePosition(currentPosition.down);
                }
            }
        }

        if(currentPosition.isLevel && !currentPosition.isLocked && currentPosition.levelToLoad!="")
        {
            LSUiHandler.instance.ShowLevelInfo(currentPosition);
            
            if (Input.GetButtonDown("Jump"))
            {
                LevelStart();
            }
        }
    }

    public void ChangePosition(MapPoint nextPosition)
    {
        currentPosition = nextPosition;
        LSUiHandler.instance.HideLevelInfo();
        AudioController.instance.playSound(5);
    }

    public void LevelStart()
    {
        StartCoroutine(StartLevelCo());
    }

    public IEnumerator StartLevelCo()
    {
        AudioController.instance.playSound(4);
        
        LSUiHandler.instance.levelPanel.gameObject.SetActive(false);
        UI.darkScreen.gameObject.SetActive(true);
        UI.FadeToBlack();
        yield return new WaitForSeconds(1F);
        SceneManager.LoadScene(currentPosition.levelToLoad);
    }
}
