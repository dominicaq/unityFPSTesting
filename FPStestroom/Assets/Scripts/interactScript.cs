using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour {

    public bool debugMode = false;

    // Pickup variables
    private Transform player;

    public Transform grabHandle;

    private GameObject heldObject;

    private Rigidbody heldRigid;

    private bool carrying = false;

    private float lerp = 0;
    //

    [SerializeField] private float rayLength = 2.5f;

    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // Center of screen



    void Start () {
       player = this.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Creating ray components
        RaycastHit hit = new RaycastHit();
        Ray interactRay = Camera.main.ViewportPointToRay(rayOrigin);

        Vector3 zeroing = new Vector3(0, 0, 0);

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
            else if (hit.rigidbody != null && hit.collider.tag != "FPSController")
            {
                // Gathering required info on hit
                heldObject = hit.collider.gameObject;
                heldRigid = hit.rigidbody;
                //

                // Making object parent to player
                heldRigid.useGravity = false;
                heldObject.transform.rotation = player.transform.rotation;
                heldObject.transform.parent = grabHandle.transform;
                //heldObject.transform.position = grabHandle.transform.position;

                carrying = true;
            }
        }
        else if (Input.GetKeyDown("e") && carrying)
        {
            // Nullify Velocity
            heldRigid.useGravity = true;
            heldRigid.velocity = zeroing;
            heldRigid.angularVelocity = zeroing;
            heldRigid.AddForce(transform.up * -3f);

            // Kill any link between object and player
            heldObject.transform.parent = null;
            heldRigid = null;
            carrying = false;
        }

        // Debug mode
        if (debugMode)
        {
            Debug.DrawRay(interactRay.origin, interactRay.direction * rayLength, Color.blue);
        }
    }

    void FixedUpdate()
    {
        Vector3 rotation = new Vector3(0, 0, 0);
        if (carrying)
        {
            lerp += Time.deltaTime;
            heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, grabHandle.transform.position, lerp);
            heldObject.transform.rotation = Quaternion.RotateTowards(heldObject.transform.rotation, grabHandle.transform.rotation, lerp);
        }

    }
}
