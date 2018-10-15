using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour {

    public Transform interatableObject;

    public float pressRate = 2.5f;

    private float timeStamp = 0;

    public bool isPressed;

    private AudioSource audioData;

    private Animation Animator;

    [SerializeField] private AudioClip[] buttonClip;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        Animator = GetComponent<Animation>();
        isPressed = false;
    }

    void Update ()
    {
        if (timeStamp <= Time.time && isPressed)
        {
            timeStamp = Time.time + pressRate;
            audioData.PlayOneShot(buttonClip[0]);
            Animator.Play();

            try
            {
                stateChanger target = interatableObject.GetComponent<stateChanger>();
                target.switchState = true;
            }
            catch
            {
                Debug.Log(transform.name + " is NULL or non-viable Transform");
            }
           
        }

        // Statement to prevent button ghosting
        if (isPressed)
            isPressed = false;
    }
}
