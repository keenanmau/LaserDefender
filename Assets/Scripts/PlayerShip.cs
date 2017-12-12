using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float speed;
    Vector3 ship_position;
    public float minX, maxX;
    // Use this for initialization
    void Start () {
        speed = 1;
        ship_position = new Vector3(0.5f, this.transform.position.y, 0f);
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

        
    }
}
