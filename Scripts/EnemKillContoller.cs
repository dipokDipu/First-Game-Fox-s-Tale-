using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemKillContoller : MonoBehaviour
{
    public GameObject deathEffect;
    [Range(0, 100)] public float thresHold1, thresHold2;

    public GameObject cherry, gem;

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
        if(other.CompareTag("Enemy"))
        {
            Instantiate(deathEffect,other.transform.position, other.transform.rotation);
            other.transform.parent.gameObject.SetActive(false);
            float random = Random.Range(0, 100);
            PlayerController.instance.Bounce();
            AudioController.instance.playSound(3);
 
            if(random <=thresHold1)
            {
                Instantiate(cherry, other.transform.position, other.transform.rotation);
            }
            else if(random>thresHold1 && random<= thresHold2)
            {
                Instantiate(gem, other.transform.position, other.transform.rotation);
            }

        }
    }
}
