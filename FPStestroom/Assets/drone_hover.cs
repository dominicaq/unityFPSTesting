using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone_hover : MonoBehaviour 
{
	public Transform destination;
	private Transform drone;
	public Rigidbody rb_drone;
	public float sphereRadius = 2f;
	public GameObject[] hoverPoints;

	// Use this for initialization
	void Start () 
	{
		drone = this.transform;
		rb_drone = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate () 
	{	
		hover(5); // Height
		movement(4f, 1f); // Speed, Offset
    }

	void hover(float hoverHeight)
	{
        RaycastHit hit;
		Vector3 rayOrigin = new Vector3(0,-1,0);
        if((Physics.Raycast(drone.position, rayOrigin, out hit, hoverHeight)) && hit.transform.tag != "Unit")
		{
            float hoverEval = hit.point.y + hoverHeight;
            float hoverForce = Mathf.Max(hoverEval - drone.position.y, 0f);
            hoverForce = Mathf.Min(hoverForce, 1f);

            if(drone.position.y < hoverEval)
                rb_drone.AddForce(Vector3.up * hoverForce, ForceMode.VelocityChange);
        }
		Debug.DrawRay(drone.position, rayOrigin, Color.green);
		
		/*
		RaycastHit wall;
		Vector3 angle = (drone.forward + drone.right).normalized;
		if(Physics.Raycast(transform.position, angle, out wall, hover_height))
		{
			rb_drone.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
		}

		
		*/
	}

	void movement(float speed, float offset)
	{
		Vector3 targetRot = new Vector3( destination.position.x, drone.position.y, destination.position.z );
		Vector3 targetPostition = new Vector3(destination.position.x+offset, drone.position.y+offset, destination.position.z+offset);

 		drone.LookAt(targetRot);
		drone.position = Vector3.MoveTowards(drone.position, targetPostition, Time.deltaTime * speed);
	}
}
