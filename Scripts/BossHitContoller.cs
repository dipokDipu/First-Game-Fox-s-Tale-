using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitContoller : MonoBehaviour
{
    public BossBattleController bossController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player") && PlayerController.instance.transform.position.y > transform.position.y)
        {
            bossController.HurtState();
            PlayerController.instance.Bounce();
            gameObject.SetActive(false);
            bossController.outerBorder.SetActive(false);
            AudioController.instance.playSound(0);
        }
    }
}
