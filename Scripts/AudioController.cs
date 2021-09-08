using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    public AudioSource[] soundEffect;

    public AudioSource bgm, victorySound ,bossBattleMusic;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound(int x)
    {
        soundEffect[x].Stop();
        soundEffect[x].pitch = Random.Range(0.9f, 1.1f);
        soundEffect[x].Play();
    }

    public void VictoryMusic()
    {
        bgm.Stop();
        victorySound.Play();
    }

    public void playBossBattleMusic()
    {
        bgm.Stop();
        bossBattleMusic.Play();
    }

    public void stopBossBattleMusic()
    {
        
        bossBattleMusic.Stop();
        bgm.Play();
    }

}
