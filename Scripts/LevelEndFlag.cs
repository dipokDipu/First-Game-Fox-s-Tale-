using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class LevelEndFlag : MonoBehaviour
{
    public SpriteRenderer pole, flag;
    public Sprite yellowPole, yellowFlag, whitePole, whiteFlag;

    

    // Start is called before the first frame update
    void Start()
    {
        pole.sprite = whitePole;
        flag.sprite = whiteFlag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            pole.sprite = yellowPole;
            flag.sprite = yellowFlag;
            LevelManager.instance.LevelEnd();
            PauseMenuController.instance.enabled = false;

        }
    }
}
