using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementController : MonoBehaviour {

	public float speed = 10.0f;
	private float lifetime = 10.0f;
	private float localTime = 0.0f;

	void FixedUpdate () {
		this.transform.position += new Vector3 (0, Time.deltaTime * this.speed, 0);
		localTime += Time.fixedDeltaTime;
		if (localTime >= lifetime) {
			Destroy (this.gameObject);
		}
	}
}
