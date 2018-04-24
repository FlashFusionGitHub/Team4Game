using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FireMode {
	Blue = 0,
	Green,
	Red
};

public class WeaponActor : MonoBehaviour {

	public Camera camera;

	[SerializeField]private GameObject laserSpawnPoint;
	[SerializeField]private GameObject rayCastSpawnPoint; //used for aiming laser
	[SerializeField]private int range;

	private FireMode firemode;
	private LineRenderer laser;
	private Color laserColor;
	private bool weaponFired;
	private float weaponCoolDownTimer = 0f;
	private float weaponCoolDownTime = 0.1f;

	private bool acquiredRedLaser;
	private bool acquiredGreenLaser;
	private bool acquiredBlueLaser;

	// Use this for initialization
	void Start () {
		acquiredBlueLaser = true;
		firemode = FireMode.Blue;
		laser = gameObject.AddComponent<LineRenderer> ();
		laser.enabled = false;
		weaponFired = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		SwitchFireMode ();

		LaserColor ();

		if (Input.GetMouseButtonDown (0) && weaponFired == false) {
			ShootLaser ();
		}

		if (weaponFired == true) {
			weaponCoolDownTimer -= Time.deltaTime;

			if (weaponCoolDownTimer <= 0.0f) {
				laser.enabled = false;
				weaponFired = false;
				weaponCoolDownTimer = weaponCoolDownTime; 
			}
		}
	}

	void ShootLaser() {
		
		RaycastHit hit;

		SetUpLaser ();

		if(Physics.Raycast (laserSpawnPoint.transform.position, rayCastSpawnPoint.transform.forward, out hit, range)) {
			
			if (firemode == FireMode.Blue && acquiredBlueLaser == true) {

				if (hit.collider.tag == "Blue Enemy") {
					Debug.Log ("Killed Blue Enemy : " + hit.collider);
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
				} else {
					Debug.Log ("Blue Laser doesn't effect : " + hit.collider);
				}
			}
			
			if (firemode == FireMode.Green && acquiredGreenLaser == true) {
			
				if (hit.collider.tag == "Green Enemy") {
					Debug.Log ("Killed Green Enemy : " + hit.collider);
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
				} else {
					Debug.Log ("Green Laser doesn't effect : " + hit.collider);
				}
			}
			
			if (firemode == FireMode.Red && acquiredRedLaser == true) {

				if (hit.collider.tag == "Red Enemy") {
					Debug.Log ("Killed Red Enemy : " + hit.collider);
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
				} else {
					Debug.Log ("Red Laser doesn't effect : " + hit.collider);
				}
			}
		}


	}

	void SetUpLaser() {
		weaponFired = true;
		laser.positionCount = 2;
		laser.enabled = true;
		laser.material = new Material (Shader.Find("Particles/Additive"));
		laser.startWidth = 0.3f;
		LaserColor ();
		laser.SetPosition (0, laserSpawnPoint.transform.position);
		laser.SetPosition (1, camera.transform.forward * range + camera.transform.position);
	}

	void LaserColor() {
		if (firemode == FireMode.Blue)
			laserColor = Color.blue;
		if (firemode == FireMode.Red)
			laserColor = Color.red;
		if (firemode == FireMode.Green)
			laserColor = Color.green;

		laser.startColor = laserColor;
		laser.endColor = laserColor;
	}

	void SwitchFireMode() {
		if (Input.GetKeyDown (KeyCode.Alpha1) && acquiredBlueLaser == true) {
			firemode = FireMode.Blue;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && acquiredGreenLaser == true) {
			firemode = FireMode.Green;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && acquiredRedLaser == true) {
			firemode = FireMode.Red;
		}
	}


	public void ChangeRedLaserAcquiredState(bool state) {
		acquiredRedLaser = state;
	}

	public void ChangeGreenLaserAcquiredState(bool state) {
		acquiredGreenLaser = state;
	}

	public void ChangeBlueLaserAcquiredState(bool state) {
		acquiredBlueLaser = state;
	}
}
