using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour {

	public float hitpoints = 1000;
	public GameObject red_laser;
	public float refire_rate = 1f;
	public float laser_velocity;

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			hitpoints -= missile.getDamage ();
			missile.Hit ();
			if (hitpoints <= 0) {
				Destroy (gameObject);
			}
			Debug.Log ("Hit");
		}
	}

	void Update(){
		Fire();



	}

	void Fire(){
		Vector3 newpos = transform.position - new Vector3 (0, 2, 0);
		GameObject laserbeam = Instantiate (red_laser, newpos, Quaternion.identity) as GameObject;
		laserbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3(0, -laser_velocity);
	}

}
