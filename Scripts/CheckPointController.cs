using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{

    public static CheckPointController instance;
    private CheckPoints[] checkPointChecker;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        checkPointChecker = FindObjectsOfType<CheckPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableCheckPoint()
    {
        for(int i=0; i<checkPointChecker.Length; i++)
        {
            checkPointChecker[i].ResetCheckPoint();
        }
    }




}
