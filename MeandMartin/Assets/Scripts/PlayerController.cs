using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float sprintSpeed;
	private float sprintingMul;
	public float turnSpeed;
	private float currentTurnSpeed;
	private Rigidbody rb;
	private float xaxis;
	private float zaxis;
	private bool dashing;
	private float dashEnd;
	public float dashLength;
	public float dashSpeed;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		sprintingMul = 3.0f;
		sprintSpeed = 1.0f;
	}
	void Update(){
		if ((Input.GetKey ("q") && (dashing == false))) {
			dashEnd = Time.time + dashLength;
			dashing = true;
			sprintSpeed = dashSpeed;
		}
		if (Time.time >= dashEnd) {
			sprintSpeed = 1.0f;
			dashing = false;
			if (Input.GetKey ("space")) {
				sprintSpeed = sprintingMul;
			} else {
				sprintSpeed = 1.0f;
			}
		}


	}
	
	// Fixed Update used for player movement and physics
	void FixedUpdate () {
		zaxis = Input.GetAxis ("Horizontal");
		xaxis = Input.GetAxis ("Vertical");
		if (dashing == true) {
			currentTurnSpeed = 0;
		} else {
			currentTurnSpeed = turnSpeed;

		}
		rb.transform.Rotate (0, zaxis * currentTurnSpeed, 0);
		//rb.rotation = Quaternion.Euler (rb.rotation.x,rb.rotation.y + (zaxis * turnSpeed), rb.rotation.z);
		rb.velocity = transform.forward * xaxis * moveSpeed * sprintSpeed; //this's location here does mean the player can change direction during their dash
	}
}
