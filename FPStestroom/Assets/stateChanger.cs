using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateChanger : MonoBehaviour {

    public bool switchState = false;

    private Animation Animator;

    void Start()
    {
        Animator = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update () {
        if (switchState)
        {
            Animator.Play();
            switchState = false;
        }
	}
}
