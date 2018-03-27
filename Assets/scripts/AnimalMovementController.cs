using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovementController : MonoBehaviour {

	public float speed = 10.0f;
	private float lifetime = 20.0f;
	private float localTime = 0.0f;

	void FixedUpdate () {
		this.transform.position += new Vector3 (Time.deltaTime * this.speed, 0, 0);
		localTime += Time.fixedDeltaTime;
		if (localTime >= lifetime) {
			Destroy (this.gameObject);
		}
	}
}
