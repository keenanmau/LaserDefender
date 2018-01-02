using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float speed;
    public float minX, maxX;
	public float padding;

	public GameObject blue_laser;
	public float laser_velocity;
	private Rigidbody2D rb;

    void Start () {
		padding = .5f;
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0, distanceToCamera));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;

        
    }

	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Fire ();
		}
        moveShip();        
    }

	void Fire(){
		GameObject laserbeam = Instantiate (blue_laser, transform.position, Quaternion.identity) as GameObject;
		laserbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3(0, laser_velocity);
		//rb.velocity = ;
	}

    void moveShip()
    {

        if (Input.GetKey(KeyCode.RightArrow)){
			this.transform.position +=  Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.position +=  Vector3.left * speed * Time.deltaTime;
        }

		float newX = Mathf.Clamp (transform.position.x, minX, maxX);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

        
    }
}
