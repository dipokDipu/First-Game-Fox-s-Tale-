using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerController : MonoBehaviour
{
    public float bounceForce;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.instance.Rb.velocity = new Vector2(PlayerController.instance.Rb.velocity.x, bounceForce);
            anim.SetTrigger("bounce");
        }
    }
}
