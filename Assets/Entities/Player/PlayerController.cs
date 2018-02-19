using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float minX, maxX;
	public float padding;
	public float hit_points = 250;

	public GameObject blue_laser;
	public float laser_velocity = 10;
	public float refire_Rate = 0.1f;

    public AudioClip fireSound;

    void Start () {
		padding = .5f;
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0, distanceToCamera));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;


    }

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.01f, refire_Rate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}

        moveShip();        
    }

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();

		if(missile){
			hit_points -= missile.getDamage ();
			missile.Hit ();
			if (hit_points <= 0) {
                Die(); 
			}
		}


	}

	void Fire(){
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
        
		GameObject laserbeam = Instantiate (blue_laser, transform.position, Quaternion.identity) as GameObject;
		laserbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3(0, laser_velocity);
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

    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("Win Screen");
        Destroy(gameObject);
    }

}
