using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float speed;
    public float minX, maxX;
    // Use this for initialization
    void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0,0, distanceToCamera));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1,0, distanceToCamera));
        
    }
	
	// Update is called once per frame
	void Update () {
        moveShip();
        
    }

    void moveShip()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
			this.transform.position +=  Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			this.transform.position +=  Vector3.left * speed * Time.deltaTime;
        }

		float newX = Mathf.Clamp (transform.position.x, minX, maxX);

		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

        
    }
}
