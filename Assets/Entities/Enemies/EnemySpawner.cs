using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;

	private float minX, maxX;
	private bool movingRight = true;

	void Start () {
		
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftedge = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightedge = Camera.main.ViewportToWorldPoint (new Vector3 (1,0, distanceToCamera));
		minX = leftedge.x;
		maxX = rightedge.x;

	}

	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3(width, height));
	}

	void Update () {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float right_edge_formation = transform.position.x + (width / 2);
		float left_edge_formation = transform.position.x - (width / 2);

		if ( right_edge_formation >= maxX) {
			movingRight = false;
		}else if ( left_edge_formation <= minX){
			movingRight = true;
		}
		


	}
}
