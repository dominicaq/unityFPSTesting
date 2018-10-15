using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycle : MonoBehaviour
{

    [SerializeField] private Vector3 homeLocation = new Vector3(0, 3, 0);
    [SerializeField] private Vector3 homeRotation = new Vector3(50, -30, 0);

    [SerializeField] public Vector3 setSunRotation = new Vector3(0, 0, 0);

    public int speed = 1;
    public bool timeFreeze = true;

    // Use this for initialization
    void Start()
    {
        transform.position = homeLocation;
        //transform.rotation = setHomeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, setSunRotation, step, 0.0f);

        if (!timeFreeze)
        {
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        /*
        else
        {
            transform.rotation = Quaternion.LookRotation(homeRotation);
        }
        */
    }
}
