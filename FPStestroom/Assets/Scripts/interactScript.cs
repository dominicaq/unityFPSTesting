using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour {

    public bool debugMode = false;

    [SerializeField] private float rayLength = 2.5f;

    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // Center of screen

    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        // Creating ray components
        RaycastHit hit = new RaycastHit();
        Ray interactRay = Camera.main.ViewportPointToRay(rayOrigin);

        // Interact statements
        if (Input.GetKeyDown("e") && Physics.Raycast(interactRay, out hit, rayLength))
        {
            if (hit.collider.tag == "Button")
            {
                interactable target = hit.transform.GetComponent<interactable>();

                if (target != null)
                {
                    target.isPressed = true;
                }
            }
            else if (hit.collider.tag == "pickup")
            {
                Debug.Log("Pickup");
            }
        }

        // Debug mode
        if (debugMode)
        {
            Debug.DrawRay(interactRay.origin, interactRay.direction * rayLength, Color.blue);
        }

    }
}
