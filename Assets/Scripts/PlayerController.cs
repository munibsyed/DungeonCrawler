using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Sockets;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpDistance;
    public float jumpSpeed;
    public float rotationSpeed;
    public float targetEpsilon;

    public float targetRotationEpsilon;

    private Vector3 targetPos;
    private Vector3 startPos;

    private Vector3 targetDirection;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        targetPos = transform.position;
	    targetDirection = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
 
        Debug.Log(transform.position);
        //rotation
	    if (Vector3.Angle(transform.forward, targetDirection) > targetRotationEpsilon)
	    {
	        transform.forward = Vector3.Lerp(transform.forward, targetDirection, Time.deltaTime*rotationSpeed);
	    }

	    else
	    {
	        transform.forward = targetDirection;
	    }

        //MOVING
	    if (Vector3.Distance(transform.position, targetPos) > targetEpsilon)
	    {
	        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime*jumpSpeed);
	    }

	    //NOT MOVING
	    else
	    {
	        transform.position = targetPos;
	        startPos = transform.position;
	        if (transform.forward == targetDirection) //if we are not rotating
	        {
	            if (Input.GetKeyDown(KeyCode.W))
	            {
	                targetPos = transform.position + (transform.forward*jumpDistance);
	            }

	            else if (Input.GetKeyDown(KeyCode.S))
	            {
	                targetPos = transform.position - (transform.forward*jumpDistance);
	            }

	            else if (Input.GetKeyDown(KeyCode.D))
	            {
	                targetPos = transform.position + (transform.right*jumpDistance);
	            }

	            else if (Input.GetKeyDown(KeyCode.A))
	            {
	                targetPos = transform.position - (transform.right*jumpDistance);
	            }


	            else if (Input.GetKeyDown(KeyCode.E))
	            {
	                targetDirection = Quaternion.AngleAxis(90, transform.up)*transform.forward;
	                targetDirection = new Vector3(Mathf.Round(targetDirection.x), Mathf.Round(targetDirection.y),
	                    Mathf.Round(targetDirection.z));
	            }

                else if (Input.GetKeyDown(KeyCode.Q))
	            {
	                targetDirection = Quaternion.AngleAxis(-90, transform.up)*transform.forward;
	                targetDirection = new Vector3(Mathf.Round(targetDirection.x), Mathf.Round(targetDirection.y),
	                    Mathf.Round(targetDirection.z));
                }
            }
	    }

    }
}
