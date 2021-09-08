using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        AudioController.instance.playSound(2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime * transform.localScale.x, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") || other.CompareTag("PlayerCollider"))
        {
            PlayerHealthController.instance.DamageTaken();
            AudioController.instance.playSound(1);
            
        }
                Destroy(gameObject);

        
    }
}
