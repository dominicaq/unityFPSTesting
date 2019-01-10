using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnnouce : MonoBehaviour
{
    annouce Annoucer;
    public bool scream;
    // Start is called before the first frame update
    void Start()
    {
        Annoucer = transform.GetComponent<annouce>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scream)
        {
            Annoucer.shout("Wave 1", 2.5f);
            scream = false;
        }
    }
}
