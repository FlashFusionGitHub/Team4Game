using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {		
		float angle = 0.6f * Input.GetAxis ("Mouse Y");

		transform.Rotate (-Vector3.right, angle);
	}
}
