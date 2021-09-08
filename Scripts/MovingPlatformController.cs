using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    public Transform[] points;
    public int currentpoint;
    public float moveSpeed;
    public Transform platform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentpoint].position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(platform.position,points[currentpoint].position) <0.1f)
        {
            currentpoint++;
            if(currentpoint >= points.Length)
            {
                currentpoint = 0;
            }

        }
    }
}
