using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FireMode {
	Blue = 0,
	Green,
	Red
};

public class WeaponActor : MonoBehaviour {

	[SerializeField]private GameObject laserSpawnPoint;
	[SerializeField]private int range;

	private FireMode firemode;
	private LineRenderer laser;

	// Use this for initialization
	void Start () {
		firemode = FireMode.Blue;
		laser = gameObject.AddComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		SwitchFireMode ();

		if (Input.GetMouseButtonDown (0)) {
			ShootLaser ();
		}
	}

	void ShootLaser() {
		RaycastHit hit;

		Physics.Raycast (laserSpawnPoint.transform.position, laserSpawnPoint.transform.forward, out hit, range);

		if (firemode == FireMode.Blue) {

			laser.startColor = Color.blue;

			if (hit.collider.tag == "Blue Enemy") {
				Debug.Log ("Killed Blue Enemy : " + hit.collider);
			} else {
				Debug.Log ("Blue Laser doesn't effect : " + hit.collider);
			}
		}
		
		if (firemode == FireMode.Green) {
		
			if (hit.collider.tag == "Green Enemy") {
				Debug.Log ("Killed Green Enemy : " + hit.collider);
			} else {
				Debug.Log ("Green Laser doesn't effect : " + hit.collider);
			}
		}
		
		if (firemode == FireMode.Red) {
		
			if (hit.collider.tag == "Red Enemy") {
				Debug.Log ("Killed Red Enemy : " + hit.collider);
			} else {
				Debug.Log ("Red Laser doesn't effect : " + hit.collider);
			}
		}
	}

	void SetUpLaser() {
		laser.enabled = true;
		laser.SetPosition (0, laserSpawnPoint.transform.position);
		laser.SetPosition (1, Vector3.forward * range);
	}

	void SwitchFireMode() {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			firemode = FireMode.Blue;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			firemode = FireMode.Green;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			firemode = FireMode.Red;
		}
	}
}
