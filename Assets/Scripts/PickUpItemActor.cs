using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemActor : MonoBehaviour {

	public Collider pickUpItemCollider;

	private WeaponActor weaponActor;

	// Use this for initialization
	void Start () {
		weaponActor = GetComponent<WeaponActor> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Blue Laser PickUp") {
			Destroy (other.gameObject);
			weaponActor.ChangeRedLaserAcquiredState (true);
		}

		if (other.gameObject.tag == "Red Laser PickUp") {
			Destroy (other.gameObject);
			weaponActor.ChangeRedLaserAcquiredState (true);
		}

		if (other.gameObject.tag == "Green Laser PickUp") {
			Destroy (other.gameObject);
			weaponActor.ChangeGreenLaserAcquiredState (true);
		}
	}
}
