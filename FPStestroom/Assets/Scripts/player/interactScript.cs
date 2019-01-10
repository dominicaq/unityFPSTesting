using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactScript : MonoBehaviour {

    public bool enableInteract = true;
    public bool enableGrab = true;
    public float playerStrength = 4;
    public Transform grabHandle;
    private GameObject heldObject;
    private Rigidbody heldRigid;
    private bool carrying = false;
    private float rayLength = 2.5f;
    private Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // Center of screen
    private float lerp = 0;

	void Update ()
    {
        // Creating ray components
        RaycastHit hit = new RaycastHit();
        Ray interactRay = Camera.main.ViewportPointToRay(rayOrigin);
        
        // Interact statements
        if (Input.GetKeyDown("e") && Physics.Raycast(interactRay, out hit, rayLength) && !carrying)
        {
            interactable target = hit.transform.GetComponent<interactable>();

            if (hit.collider.tag == "Button" && target != null && enableInteract)
                target.isPressed = true;
            else if (hit.rigidbody != null && hit.collider.tag != "Unit" && enableGrab)
            {
                // Gathering required info on hit
                heldObject = hit.collider.gameObject;
                heldRigid = hit.rigidbody;
                Vector3 geometry = heldObject.transform.localScale;
                float grabVolume = geometry.x * geometry.y * geometry.z;

                // Disallow large volume grabs
                if (grabVolume < playerStrength)
                {
                    heldRigid.useGravity = false;
                    heldObject.transform.parent = grabHandle.transform;
                    carrying = true;
                }
            }
        }
        else if (Input.GetKeyDown("e") && carrying)
            Drop();

        //Debug.DrawRay(interactRay.origin, interactRay.direction * rayLength, Color.blue);
    }

    void Drop()
    {
        Vector3 zeroing = new Vector3(0, 0, 0);
        // Nullify Velocity
        heldRigid.useGravity = true;
        heldRigid.AddForce(transform.up * -3f);
        heldRigid.velocity = zeroing;
        heldRigid.angularVelocity = zeroing;

        // Kill link
        heldObject.transform.parent = null;
        carrying = false;
    }

    void FixedUpdate()
    {
        if (carrying)
        {
            // Need to find fix for object moving through walls
            lerp += Time.deltaTime;
            try
            {
                heldObject.transform.position = Vector3.MoveTowards(heldObject.transform.position, grabHandle.transform.position, lerp);
                heldObject.transform.LookAt(this.transform);
            }
            catch
            {
                carrying = false;
            }
        }
    }
}
