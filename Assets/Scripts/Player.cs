using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static bool moving;
	public Camera cam;
	public GameObject bullet;
	public GameObject sky;
	public GameObject sky2;
	public GameObject ground;
	public GameObject ground2;
	public static float distance;

	public static int playerHealth = 3;

	private float maxWidth;
	Vector3 pos;
	private Vector3 normalizedDirection;
	private float xDiff;
	private float yDiff;
	//private int maxBullets = 6;
	public int currentNumberOfBullets;

	// Use this for initialization
	void Start () {
		moving = false;
		distance = 0;
		if (cam == null) {
			cam = Camera.main;
		}
		currentNumberOfBullets = 0;
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float playerWidth = GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - playerWidth/2;

		pos = Input.mousePosition;
		pos.z = 20;
	}

	public int getCurrentNumberOfBullets() {
		return currentNumberOfBullets;
	}

	// Update is called once per frame
	void FixedUpdate () {
		moving = false;
		if (Input.GetKey ("d")) {
			Vector3 newPosition = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
			if (newPosition.x < -1.5) {
				transform.position = newPosition;
				moving = false;
			} else {
				moving = true;
				Move (sky);
				Move (sky2);
				Move2 (ground);
				Move2 (ground2);
				distance += 0.1f;
			}
				
		} else if (Input.GetKey ("a")) {
			Vector3 newPosition = new Vector3 (transform.position.x - 0.1f, transform.position.y, transform.position.z);
			if (newPosition.x > -maxWidth) {
				transform.position = newPosition;
			}
		} 
	}

	void Move(GameObject gameObj) {
		gameObj.transform.position = new Vector3 (gameObj.transform.position.x-0.03f, gameObj.transform.position.y, gameObj.transform.position.z);
		if (gameObj.transform.position.x < -11.96f) {
			gameObj.transform.position = new Vector3 (11.96f, gameObj.transform.position.y, gameObj.transform.position.z);
		} 
	}

	void Move2(GameObject gameObj) {
		gameObj.transform.position = new Vector3 (gameObj.transform.position.x-0.06f, gameObj.transform.position.y, gameObj.transform.position.z);
		if (gameObj.transform.position.x < -12.7f) {
			gameObj.transform.position = new Vector3 (12.8f, gameObj.transform.position.y, gameObj.transform.position.z);
		} 
	}
	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.tag == "Zombie") {
			Debug.Log (" Player Collide ");
			Destroy (col.gameObject);
			playerHealth--;
			/*
			if (playerHealth > 0) {
				Destroy (col.gameObject);
				playerHealth--;
			}
			*/
		}
	}

}
