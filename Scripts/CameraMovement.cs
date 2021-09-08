using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    public Transform player;
    public Transform backGround;
    public Transform mountain;

    public float minHeight, maxHeight;

    private Vector2 lastPos;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = new Vector3(player.position.x, Mathf.Clamp(player.position.y,minHeight, player.position.y+maxHeight), transform.position.z);
        Vector2 distanceCov = new Vector2(transform.position.x-lastPos.x, transform.position.y - lastPos.y);
        backGround.position += new Vector3(distanceCov.x, distanceCov.y, 0f);
        mountain.position += new Vector3(distanceCov.x, distanceCov.y, 0f) * 0.5f;
        lastPos = transform.position;

    }
}
