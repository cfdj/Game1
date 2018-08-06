using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
	public GameObject Player;
	private Rigidbody rb;
	public float MoveSpeed;
	public float range;
	private Transform target;
	public int health;


	public Animator EnemyAnimator;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		EnemyAnimator = GetComponent<Animator> ();

		Player = GameObject.Find ("Player");
		target = Player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		rb.transform.LookAt (target.position);
		if (Vector3.Distance (target.position, rb.position) > range) {
			EnemyAnimator.SetBool ("SpearStab", false);
			rb.velocity = transform.forward * MoveSpeed;
		} else {
			rb.velocity = new Vector3 (0, 0, 0);
			EnemyAnimator.SetBool ("SpearStab", true);
		}
	}
	public void Hit(int damage){
		health -= damage;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}
}
