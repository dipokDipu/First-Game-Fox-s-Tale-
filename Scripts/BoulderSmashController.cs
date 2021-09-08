using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSmashController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    public int currentpoint;
    public float moveSpeed;
    public Transform boulderSmash;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(boulderSmash.position, PlayerController.instance.transform.position) < 8f)
        {
            boulderSmash.position = Vector3.MoveTowards(boulderSmash.position, points[currentpoint].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(boulderSmash.position, points[currentpoint].position) < 0.1f)
            {
                currentpoint++;
                if (currentpoint >= points.Length)
                {
                    currentpoint = 0;
                }

            }
        }
        else
        {
            boulderSmash.position = Vector3.MoveTowards(boulderSmash.position, points[0].position, moveSpeed * Time.deltaTime);
            currentpoint = 1;
        }
    }

}
