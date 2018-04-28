using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerActor : MonoBehaviour {

	private CharacterController player;
	private float playerSpeed;

	[SerializeField]private float walkSpeed;
	[SerializeField]private float sprintSpeed;
	[SerializeField]private float turningSpeed;
	[SerializeField]private float gravity;
	[SerializeField]private Camera playerCamera;

	public float health = 100;
	public Image currentHealth;
	public Text healthPercentage;

	private float max_health = 100;


	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		//Apply gravity
		Gravity ();

		//Player Controls
		PlayerTurn();
		PlayerMovement ();
		PlayerSprint ();

		LookUpAndDown ();
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

	void LookUpAndDown() {

		Vector3 angles = playerCamera.transform.eulerAngles + (Vector3.right * -Input.GetAxis ("Mouse Y")) * turningSpeed;

		if (angles.x > 180)
			angles.x -= 360;

		angles.x = Mathf.Clamp (angles.x, -10, 30);

		playerCamera.transform.eulerAngles = angles;
	}

	void PlayerSprint() {
		if (Input.GetKey (KeyCode.LeftShift)) {
			playerSpeed = sprintSpeed;
		} else {
			playerSpeed = walkSpeed;
		}
	}

	void UpdateHealthBar() {
		float ratio = health / max_health;
		currentHealth.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		healthPercentage.text = (ratio * 100).ToString() + '%';
	}

	public void TakeDamage(float damage) {
		health -= damage;

		if (health <= 0) {
			//Load Death scene
			SceneManager.LoadScene(1);
		}

		UpdateHealthBar ();
	}

	private void HealPlayer(float healAmount) {
		health += healAmount;

		if (health > max_health) {
			health = max_health;
		}

		UpdateHealthBar ();
	}

	void OnTriggerEnter(Collider hit) {
		if (hit.tag == "Blue Laser") {
			TakeDamage (5);
		}

		if (hit.tag == "Green Laser") {
			TakeDamage (5);
		}

		if (hit.tag == "Red Laser") {
			TakeDamage (5);
		}
	}
}
