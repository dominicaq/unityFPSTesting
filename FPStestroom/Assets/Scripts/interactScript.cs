using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour {

    public bool debugMode = false;

    private Transform player;

    public Transform grabHandle;

    private GameObject heldObject;

    private Rigidbody heldRigid;

    [SerializeField] private float rayLength = 2.5f;

    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // Center of screen

    private bool carrying = false;

    void Start () {
       player = this.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Creating ray components
        RaycastHit hit = new RaycastHit();
        Ray interactRay = Camera.main.ViewportPointToRay(rayOrigin);

        // Interact statements
        if (Input.GetKeyDown("e") && Physics.Raycast(interactRay, out hit, rayLength) && !carrying)
        {
            interactable target = hit.transform.GetComponent<interactable>();

            if (hit.collider.tag == "Button")
            {
                if (target != null)
                {
                    target.isPressed = true;
                }
            }
            else if (hit.collider.tag == "pickup")
            {
                // Gathering required info on hit
                heldObject = hit.collider.gameObject;
                heldRigid = hit.rigidbody;

                //
                heldRigid.GetComponent<Rigidbody>().useGravity = false;
                heldRigid.GetComponent<Rigidbody>().isKinematic = true;
                heldObject.transform.rotation = player.transform.rotation;
                heldObject.transform.parent = grabHandle.transform;
                heldObject.transform.position = grabHandle.transform.position;
                //

                carrying = true;
            }
        }
        else if (Input.GetKeyDown("e") && carrying)
        {
            heldRigid.GetComponent<Rigidbody>().useGravity = true;
            heldRigid.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.parent = null;
            carrying = false;
        }
            
        // Debug mode
        if (debugMode)
        {
            Debug.DrawRay(interactRay.origin, interactRay.direction * rayLength, Color.blue);
        }

    }
}
