using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : MonoBehaviour {

	private CharacterController player;
	private float playerSpeed;


	[SerializeField]private float walkSpeed;
	[SerializeField]private float sprintSpeed;
	[SerializeField]private float turningSpeed;
	[SerializeField]private float gravity;

	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Apply gravity
		Gravity ();

		//Player Controls
		PlayerTurn();
		PlayerMovement ();
		PlayerSprint ();
	}

	void Gravity() {
		player.Move (new Vector3(0, -(gravity * Time.deltaTime), 0));
	}

	void PlayerMovement() {
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * playerSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-(Vector3.right * playerSpeed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-(Vector3.forward * playerSpeed * Time.deltaTime));
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * playerSpeed * Time.deltaTime);
		}
	}

	void PlayerTurn() {
		transform.Rotate (Vector3.up, turningSpeed * Input.GetAxis("Mouse X"));
	}

	void PlayerSprint() {
		if (Input.GetKey (KeyCode.LeftShift)) {
			playerSpeed = sprintSpeed;
		} else {
			playerSpeed = walkSpeed;
		}
	}
}
