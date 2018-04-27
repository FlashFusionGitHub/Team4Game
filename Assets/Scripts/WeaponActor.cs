using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	[SerializeField]private Image greenGunImage;
	[SerializeField]private Image redGunImage;
	[SerializeField]private Image blueGunImage;
	[SerializeField]private Text killCountText;

	private FireMode firemode;
	private LineRenderer laser;
	private Color laserColor;
	private EnemyAIActor enemyAIActor;
	private bool weaponFired;
	private float weaponCoolDownTimer = 0f;
	private float weaponCoolDownTime = 0.1f;
	private int killCount;

	private bool acquiredRedLaser;
	private bool acquiredGreenLaser;
	private bool acquiredBlueLaser;

	// Use this for initialization
	void Start () {
		acquiredBlueLaser = true;
		firemode = FireMode.Blue;
		laser = gameObject.AddComponent<LineRenderer> ();
		enemyAIActor = GameObject.FindObjectOfType<EnemyAIActor> ();
		laser.enabled = false;
		weaponFired = false;
		killCount = 0;
		killCountText.text = "Kills : 0";

		blueGunImage.enabled = true;
		greenGunImage.enabled = false;
		redGunImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		SwitchFireMode ();

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

		killCountText.text = "Kills : " + killCount;
	}

	void ShootLaser() {
		
		RaycastHit hit;

		SetUpLaser ();

		if(Physics.Raycast (laserSpawnPoint.transform.position, rayCastSpawnPoint.transform.forward, out hit, range)) {
			
			if (firemode == FireMode.Blue) {

				if (hit.collider.tag == "Blue Enemy") {
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
				}
			}
			
			if (firemode == FireMode.Green) {
			
				if (hit.collider.tag == "Green Enemy") {
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
				}
			}
			
			if (firemode == FireMode.Red) {

				if (hit.collider.tag == "Red Enemy") {
					hit.transform.gameObject.GetComponent<EnemyAIActor> ().EnemyTakeDamage (50);
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
			blueGunImage.enabled = true;
			greenGunImage.enabled = false;
			redGunImage.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2) && acquiredGreenLaser == true) {
			firemode = FireMode.Green;
			blueGunImage.enabled = false;
			greenGunImage.enabled = true;
			redGunImage.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3) && acquiredRedLaser == true) {
			firemode = FireMode.Red;
			blueGunImage.enabled = false;
			greenGunImage.enabled = false;
			redGunImage.enabled = true;
		}

		LaserColor ();
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

	public void KillCountAddOne() {
		killCount++;
	}
}
