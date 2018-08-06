using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
	public int damage;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		Debug.Log ("Hit");
		col.gameObject.SendMessage ("Hit", damage);
	}
}
