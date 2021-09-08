using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIController : MonoBehaviour
{
    public static AIController instance;

    

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActive()
    {
        gameObject.SetActive(true);
    }

    public void setDisable()
    {
        gameObject.SetActive(false);
    }
}
