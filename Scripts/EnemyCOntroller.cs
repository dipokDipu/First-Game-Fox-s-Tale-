using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCOntroller : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D theRb;
    public SpriteRenderer theSr;

    public Animator anim;

    public Transform leftFrogBarrier, rightFrogBarrier;

    public float moveDuration, waitDuration;
    private float moveCounter, waitCounter;

    public bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theRb = GetComponent<Rigidbody2D>();
        leftFrogBarrier.parent = null;
        rightFrogBarrier.parent = null;
        movingRight = false;
        moveCounter = moveDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (rightFrogBarrier.position != leftFrogBarrier.position)
        {
            if (moveCounter > 0)
            {
                moveCounter -= Time.deltaTime;

                if (moveCounter <= 0f)
                {
                    waitCounter = Random.Range(waitDuration * 1.60f, waitDuration * 2.35f);
                }


                if (movingRight)
                {
                    theRb.velocity = new Vector2(moveSpeed, theRb.velocity.y);
                    theSr.flipX = true;

                    if (transform.position.x > rightFrogBarrier.position.x)
                    {
                        movingRight = false;
                    }
                }
                else
                {
                    theRb.velocity = new Vector2(-moveSpeed, theRb.velocity.y);
                    theSr.flipX = false;

                    if (transform.position.x < leftFrogBarrier.position.x)
                    {
                        movingRight = true;
                    }
                }

                anim.SetBool("isMoving", true);
            }
            else
            {
                waitCounter -= Time.deltaTime;
                theRb.velocity = new Vector2(0f, theRb.velocity.y);
                if (waitCounter <= 0f)
                {
                    moveCounter = Random.Range(moveDuration * .75f, moveDuration * 1.5f);
                }
                anim.SetBool("isMoving", false);
            }
        }
        else
        {
            moveCounter -= Time.deltaTime;
            if(moveCounter<=0)
            {
                moveCounter = moveDuration;
                theSr.flipX = !theSr.flipX;
            }
            
        }

    }
}
