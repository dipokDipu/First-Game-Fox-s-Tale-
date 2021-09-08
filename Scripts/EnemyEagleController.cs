using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyEagleController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public int currentpoint;
    public float moveSpeed;

    public float distance;
    public SpriteRenderer Sr;

    public AIPath aiPath;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distance)
        {

            //AIController.instance.setDisable();
            aiPath.enabled = false;

            transform.position = Vector3.MoveTowards(transform.position, points[currentpoint].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[currentpoint].position) < 0.1f)
            {
                currentpoint++;
                if (currentpoint >= points.Length)
                {
                    currentpoint = 0;
                }

            }

            if (transform.position.x > points[currentpoint].position.x)
            {
                Sr.flipX = false;
            }
            else if (transform.position.x < points[currentpoint].position.x)
            {
                Sr.flipX = true;
            }
        }

        else
        {
            currentpoint = 1;
            //AIController.instance.setActive();
            aiPath.enabled = true;
            if (aiPath.desiredVelocity.x >=.01f)
            {
                //transform.localScale = new Vector3(-1f, 1f, 1f);
                Sr.flipX = true;
            }
            else if(aiPath.desiredVelocity.x <=-.01f)
            {
                //transform.localScale = new Vector3(1f, 1f, 1f);
                Sr.flipX = false;
            }
        }
    }
}
