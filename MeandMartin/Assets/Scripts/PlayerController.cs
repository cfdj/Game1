using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	public float sprintSpeed;
	private float sprintingMul;
	public float turnSpeed;
	private Rigidbody rb;
	private float xaxis;
	private float zaxis;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		sprintingMul = 3.0f;
		sprintSpeed = 1.0f;
	}
	void Update(){
		if (Input.GetKey ("space")) {
			sprintSpeed = sprintingMul;
		} else {
			sprintSpeed = 1.0f;
		}
	}
	
	// Fixed Update used for player movement and physics
	void FixedUpdate () {
		zaxis = Input.GetAxis ("Horizontal");
		xaxis = Input.GetAxis ("Vertical");
		rb.transform.Rotate (0, zaxis * turnSpeed, 0);
		//rb.rotation = Quaternion.Euler (rb.rotation.x,rb.rotation.y + (zaxis * turnSpeed), rb.rotation.z);
		rb.velocity = transform.forward * xaxis * moveSpeed * sprintSpeed;
	}
}
