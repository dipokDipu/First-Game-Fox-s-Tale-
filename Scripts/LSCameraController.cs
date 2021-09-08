using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    public Vector2 minHeight,maxHeight;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, minHeight.x, maxHeight.x), Mathf.Clamp(player.position.y, minHeight.y, maxHeight.y),transform.position.z);
    }
}
