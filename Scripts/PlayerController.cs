using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D Rb;
    public float jumpSpeed;
    private bool onGround;
    public Transform checkPosition;
    public LayerMask groundLayer;
    private bool doubleJump;
    private Animator playerAnimation;
    private SpriteRenderer Sr;

    public float bounceForce;

    public float knockBackForce, knockBackDuration;
    private float knockBackCounter = 0f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (knockBackCounter <= 0)
        {
                Rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), Rb.velocity.y);

                if (Rb.velocity.x > 0)
                    Sr.flipX = false;
                else if (Rb.velocity.x < 0)
                    Sr.flipX = true;


                onGround = Physics2D.OverlapCircle(checkPosition.position, .2f, groundLayer);
                if (Input.GetButtonDown("Jump"))
                {
                    if (onGround)
                    {
                        Rb.velocity = new Vector2(Rb.velocity.x, jumpSpeed);
                        doubleJump = true;
                        AudioController.instance.playSound(10);
                    }
                    else
                    {
                        if (doubleJump)
                        {
                            Rb.velocity = new Vector2(Rb.velocity.x, jumpSpeed);
                            doubleJump = false;
                            AudioController.instance.playSound(10);
                        }
                    }
                
                }

            }
            else
            {
                knockBackCounter -= Time.deltaTime;

                if (Sr.flipX)
                {
                    Rb.velocity = new Vector2(knockBackForce, Rb.velocity.y);
                }
                else if (!Sr.flipX)
                {
                    Rb.velocity = new Vector2(-knockBackForce, Rb.velocity.y);
                }

            }
    

        playerAnimation.SetBool("onGround", onGround);
        playerAnimation.SetFloat("moveSpeed", Mathf.Abs(Rb.velocity.x));



    }

    public void KnockBack()
    {
        knockBackCounter = knockBackDuration;
        Rb.velocity = new Vector2(0f, knockBackForce);
        playerAnimation.SetTrigger("playerHurt");
        
        
    }

    public void Bounce()
    {
        Rb.velocity = new Vector2(Rb.velocity.x, bounceForce);
        AudioController.instance.playSound(10);

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "platform")
        {
            transform.parent = null;
        }
    }
}
