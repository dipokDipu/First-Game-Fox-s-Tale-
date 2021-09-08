using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool isCherry,isGem;
    public bool isCollected;
    public GameObject pickupEffect;

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
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemCollected++;
                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                UiHandler.instance.gemText();
                AudioController.instance.playSound(6);
            }
            
            if(isCherry)
            {
                if (isCherry && PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.Heal();
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                    AudioController.instance.playSound(7);
                }
            }

        }
    }
}
