﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	
	public float damage;

	public float getDamage(){
		return damage;
	}
	public void Hit(){
		Destroy (gameObject);
	}
}
