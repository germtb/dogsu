using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour {

	public GameObject car;
	public float cooldown = 1.0f;

	private float localTime = 0.0f;

	void FixedUpdate () {
		if (localTime < cooldown) {
			localTime += Time.fixedDeltaTime;
		} else {
			Instantiate (
				car,
				new Vector3 (Random.Range (0, 2) - 0.5f, -10, 0),
				Quaternion.identity
			);
			localTime = 0.0f;
		}

	}
}
