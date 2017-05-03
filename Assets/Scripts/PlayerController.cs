using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpDistance;
    public float jumpSpeed;
    public float rotationSpeed;
    public float targetEpsilon;

    private Vector3 targetPos;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        targetPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {
		
        //MOVING
        if (Vector3.Distance(transform.position, targetPos) > targetEpsilon)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * jumpSpeed);
        }

        //NOT MOVING
        else
        {
            transform.position = targetPos;
            startPos = transform.position;
            if (Input.GetKeyDown(KeyCode.W))
            {
                targetPos = transform.position + (transform.forward * jumpDistance);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                targetPos = transform.position - (transform.forward * jumpDistance);
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetPos = transform.position + (transform.right * jumpDistance);
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                targetPos = transform.position - (transform.right * jumpDistance);
            }

        }


    }
}
