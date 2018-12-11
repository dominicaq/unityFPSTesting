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
	public float hover_height = 2f;

	// Use this for initialization
	void Start () 
	{
		drone = this.transform;
		rb_drone = GetComponent<Rigidbody>();
	}
	
    void FixedUpdate () 
	{	
		hover();
		movement(3);	
    }

	void hover()
	{
        RaycastHit hit;
        if(Physics.Raycast(drone.position, Vector3.down, out hit, hover_height))
		{
            float hoverEval = hit.point.y + hover_height;
            float hoverForce = Mathf.Max(hoverEval - drone.position.y, 0f);
            hoverForce = Mathf.Min(hoverForce, 1f);

            if(drone.position.y < hoverEval)
                rb_drone.AddForce(Vector3.up * hoverForce, ForceMode.VelocityChange);
        }

		/*
		RaycastHit wall;
		Vector3 angle = (drone.forward + drone.right).normalized;
		if(Physics.Raycast(transform.position, angle, out wall, hover_height))
		{
			rb_drone.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
		}

		Debug.DrawRay(hit.origin, hit.direction * hover_height, Color.green);
		*/
	}

	void movement(int speed)
	{
		float offset = 1f;
		//rb_drone.MovePosition(destination.position + transform.forward * Time.deltaTime/2);
		Vector3 targetRot = new Vector3( destination.position.x, drone.position.y, destination.position.z );
		Vector3 targetPostition = new Vector3(destination.position.x+offset, drone.position.y+offset, destination.position.z+offset);

 		drone.LookAt(targetRot);
		drone.position = Vector3.MoveTowards(drone.position, targetPostition, Time.deltaTime * speed);
	}
}
