using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActor : MonoBehaviour {

	public float stopPosition;

	private bool openDoor;

	// Use this for initialization
	void Start () {
		openDoor = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (openDoor) {
			if (transform.position.y < stopPosition)
				transform.Translate (Vector3.up * 5.0f * 1 * Time.deltaTime);
		}
	}


	public void SetDoorState(bool state) {
		openDoor = state;
	}
}
