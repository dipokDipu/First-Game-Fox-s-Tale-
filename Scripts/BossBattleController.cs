using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleController : MonoBehaviour
{
    public enum bossState {shooting, hurt, moving ,ended };
    public bossState state;
    public Transform bigBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool isRight;

    [Header("Bullet")]
    public GameObject bullet;
    public float firingRate;
    private float counterFireTime;
    public Transform firingPositon;

    [Header("Hurt")]
    public float hurtTime;
    private float counterHurtTime;
    public GameObject hitCollider ,outerBorder;

    [Header("Mine")]
    public GameObject bossMine;
    public float mineInterval;
    public Transform minePosition;
    private float counterMineInterval;

    [Header("Health")]
    public int bossHealth;
    public GameObject explosion;
    public GameObject bounceActivated;
    
    
    // Start is called before the first frame update
    void Start()
    {
        state = bossState.shooting;
        //state = 0;
    }

    // Update is called once per frame
    void Update()
    {

        switch(state)
        {
            case bossState.shooting:

                    if (counterFireTime > 0)
                    {
                        counterFireTime -= Time.deltaTime;
                    }
                    else
                    {
                        counterFireTime = firingRate;

                        var Bullet = Instantiate(bullet, firingPositon.position, firingPositon.rotation);
                        //Debug.Log(bullet.transform.localScale)
                        Bullet.transform.localScale = bigBoss.localScale;
                    }
                break;
            
            case bossState.hurt:
                if(counterHurtTime>0)
                {
                    counterHurtTime -= Time.deltaTime;
                }
                else
                {
                    state = bossState.moving;
                    counterMineInterval = .5f;
                }

                break;

            case bossState.moving:
                if(isRight)
                {
                    bigBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if(bigBoss.position.x > rightPoint.position.x)
                    {
                        isRight = false;
                        counterFireTime = 0f;
                        state = bossState.shooting;
                        bigBoss.localScale = new Vector3(1f, 1f, 1f);
                        anim.SetTrigger("open");
                        hitCollider.SetActive(true);
                        outerBorder.SetActive(true);
                        /*MineContoller[] mines = FindObjectsOfType<MineContoller>();
                        if(mines.Length>0)
                        {
                            foreach(MineContoller foundMines in mines)
                            {
                                foundMines.Explosion();
                            }
                        }*/
                    }
                }
                else
                {
                    bigBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if (bigBoss.position.x < leftPoint.position.x)
                    {
                        isRight = true;
                        counterFireTime = 0f;
                        state = bossState.shooting;
                        bigBoss.localScale = new Vector3(-1f, 1f, 1f);
                        anim.SetTrigger("open");
                        hitCollider.SetActive(true);
                        outerBorder.SetActive(true);
                        /*MineContoller[] mines = FindObjectsOfType<MineContoller>();
                        if (mines.Length > 0)
                        {
                            foreach (MineContoller foundMines in mines)
                            {
                                foundMines.Explosion();
                            }
                        }*/
                    }
                }

                if(counterMineInterval>0)
                {
                    counterMineInterval -= Time.deltaTime;
                   
                }
                else if(counterMineInterval<=0)
                {
                    counterMineInterval = mineInterval;
                    Instantiate(bossMine, minePosition.position, minePosition.rotation);
                    
                }


                break;

            case bossState.ended:
                AudioController.instance.playSound(3);
                Instantiate(explosion, bigBoss.transform.position, bigBoss.transform.rotation);
                bounceActivated.SetActive(true);
                gameObject.SetActive(false);
                AudioController.instance.stopBossBattleMusic();
                

                break;
        }
#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H))
        {
            HurtState();
        }
#endif
    }

    public void HurtState()
    {
        counterHurtTime = hurtTime;
        state = bossState.hurt;
        anim.SetTrigger("hurt");
        hitCollider.SetActive(false);
        outerBorder.SetActive(false);
        bossHealth--;
        firingRate /=1.2f;
        mineInterval /= 1.2f;
        if(bossHealth<=0)
        {
            state = bossState.ended;
        }
    }
}
