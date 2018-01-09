using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationController: MonoBehaviour {

	public float hitpoints = 1000;
	public GameObject red_laser;
	public float refire_rate = 1f;
	public float laser_velocity;
	public float shots_per_second = 0.5f;

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			hitpoints -= missile.getDamage ();
			missile.Hit ();
			if (hitpoints <= 0) {
				Destroy (gameObject);
			}
		}
	}

	void Update(){
		float probability = Time.deltaTime * shots_per_second;
		if(Random.value < probability){
			Fire();
		}

		allMembersDead ();
			//Debug.Log ("All enemies dead");
		
	}

	bool allMembersDead(){
		Debug.Log (transform);
		foreach(Transform childPositionGameObject in transform){
			Debug.Log ("child");
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void Fire(){
		Vector3 newpos = transform.position - new Vector3 (0, 2, 0);
		GameObject laserbeam = Instantiate (red_laser, newpos, Quaternion.identity) as GameObject;
		laserbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3(0, -laser_velocity);
	}

}
