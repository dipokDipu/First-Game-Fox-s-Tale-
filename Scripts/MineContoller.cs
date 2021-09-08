using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineContoller : MonoBehaviour
{
    public GameObject explosion;
    public float stayTIme, couterTime;
    public SpriteRenderer sp;
    //public MineContoller instance;
    // Start is called before the first frame update

    void Start()
    {
        
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - .1f*Time.deltaTime);
        if(sp.color.a <.4f)
        {
            Destroy(gameObject);
            AudioController.instance.playSound(3);
        }

        /*if(couterTime>0)
        {
            couterTime -= .5f* Time.deltaTime;
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, sp.color.a - (1f-couterTime*.5f));
            Debug.Log("hello");

            if (couterTime<=0 )
            {
                Destroy(gameObject);
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerHealthController.instance.DamageTaken();
            Instantiate(explosion, transform.position, transform.rotation);
        }

    }

    public void Explosion()
    {
        couterTime = stayTIme;
    }
}
