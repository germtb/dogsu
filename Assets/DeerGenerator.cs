using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerGenerator : MonoBehaviour {
	public GameObject deer;
	public float cooldown = 1.0f;

	private float localTime = 0.0f;

	void FixedUpdate () {
		if (localTime < cooldown) {
			localTime += Time.fixedDeltaTime;
		} else {
			Instantiate (
				deer,
				new Vector3 (-10, Random.Range (-2, 3) - 0.5f, 0),
				Quaternion.identity
			);
			localTime = 0.0f;
		}

	}

}
