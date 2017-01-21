﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSprite : MonoBehaviour {
	private float speed = 0.01f;
	public int STARTINGHP = 100;
	public int CURRENTHP;


	// Use this for initialization
	void Start () {
		CURRENTHP = STARTINGHP;
	}
		
	// Update is called once per frame
	void Update() {
		moveZombie ();
		if (CURRENTHP < 0) {
			Destroy (gameObject);
		}
	}

	void moveZombie(){
		Vector2 position = this.transform.position;
		position.x=position.x - speed;
		this.transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D coll){
		//Debug.Log ("collision");
		Destroy (coll.gameObject);
		CURRENTHP = CURRENTHP - 50;
	}

}
