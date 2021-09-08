using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float invinsibilty;
    private float invinsibityCounter;

    public SpriteRenderer sp;

    public CapsuleCollider2D deactive;

    public float currentHealth, maxHealth;

    public GameObject death;




    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        deactive = gameObject.GetComponent<CapsuleCollider2D>();
        currentHealth = maxHealth;
        LevelManager.instance.respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
        
        if(invinsibityCounter>0)
        {
            invinsibityCounter -= Time.deltaTime;
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a + .3f*Time.deltaTime);
        }
    }
    public void DamageTaken()
    {
        if(invinsibityCounter <= 0)
        {
            currentHealth -= 0.50f;

            if (currentHealth <= 0.00f)
            {
                Instantiate(death, transform.position, transform.rotation);
                LevelManager.instance.Respawn();

                //(gameObject.GetComponent(typeof(CapsuleCollider2D)) as Collider).isTrigger = false;
            }
            else
            {
                invinsibityCounter = invinsibilty;
                sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, 0.4f);
                PlayerController.instance.KnockBack();
                UiHandler.instance.displayHealth();
                AudioController.instance.playSound(9);
            }

        }

        

        
    }

    public void Heal()
    {
        currentHealth += 0.50f;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        UiHandler.instance.displayHealth();
    }


}
