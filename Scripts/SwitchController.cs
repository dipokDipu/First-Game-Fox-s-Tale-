using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject door;
    public SpriteRenderer Sr;
    public Sprite on,off;
    public bool deActive;
    // Start is called before the first frame update
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (deActive)
            {
                Sr.sprite = off;
                door.SetActive(false);
                deActive = false;
            }
            else
            {
                Sr.sprite = on;
                door.SetActive(true);
                deActive = true;
            }

        }
    }
}
