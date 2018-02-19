using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFormation: MonoBehaviour {

	public float hitpoints = 1000;
	public GameObject red_laser;
	public float refire_rate = 1f;
	public float laser_velocity;
	public float shots_per_second = 0.5f;
    public int score_value = 100;

    private ScoreKeeper scorekeeper;
    public AudioClip fireSound;
    public AudioClip deathSound;

    void Start()
    {
        scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

    }

    void Update(){
		float probability = Time.deltaTime * shots_per_second;
		if(Random.value < probability){
			Fire();
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			hitpoints -= missile.getDamage ();
			missile.Hit ();
			if (hitpoints <= 0) {
                scorekeeper.Score(score_value);
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy (gameObject);
			}
		}
	}

	void Fire(){
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
		GameObject laserbeam = Instantiate (red_laser, transform.position, Quaternion.identity) as GameObject;
		laserbeam.GetComponent<Rigidbody2D> ().velocity = new Vector3(0, -laser_velocity);
	}

}
