using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float moveSpeed;
	private Rigidbody rb;
	private float xaxis;
	private float zaxis;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Fixed Update used for player movement and physics
	void FixedUpdate () {
		xaxis = Input.GetAxis ("Horizontal");
		zaxis = Input.GetAxis ("Vertical");
		rb.velocity = new Vector3 (xaxis * moveSpeed, rb.velocity.y, zaxis * moveSpeed);
	}
}
