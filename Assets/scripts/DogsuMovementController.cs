using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsuMovementController : MonoBehaviour {

	public float cooldown = 0.5f;
	public float step = 1f;

	public float hLimit = 0.6f;
	public float vLimit = 10f;

	private bool beingHit = false;
	private float localTime = 0f;

	public float animationSpeed = 1f;
	public float animationDuration = 1f;
	public float dieSpeed = 1f;
	private Vector3 dieDirection;

	public bool enabled = true;

	void Start () {
		Dogsu.healthController.OnDie += () =>
			StartCoroutine(
				Extensions.DoAfter(
					() => { enabled = false; },
					animationDuration
				)
			);
	}

	void Update () {
		if (!enabled) {
			return;
		}

		if (beingHit) {
			return;
		}

		if (localTime < cooldown) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 newPosition = this.transform.position - new Vector3(step, 0f, 0f);
			if (newPosition.x > -hLimit) {
				this.transform.position = newPosition;
				localTime = 0f;
			}
		} else if (Input.GetKeyDown(KeyCode.D)) {
			Vector3 newPosition = this.transform.position + new Vector3(step, 0f, 0f);
			if (newPosition.x < hLimit) {
				this.transform.position = newPosition;
				localTime = 0f;
			}
		} else if (Input.GetKeyDown(KeyCode.W)) {
			Vector3 newPosition = this.transform.position + new Vector3(0f, 1f, 0f);
			if (newPosition.y < vLimit) {
				this.transform.position = newPosition;
				localTime = 0f;
			}
		} else if (Input.GetKeyDown(KeyCode.S)) {
			Vector3 newPosition = this.transform.position - new Vector3(0f, 1f, 0f);
			if (newPosition.y > -vLimit) {
				this.transform.position = newPosition;
				localTime = 0f;
			}
		}
	}

	void FixedUpdate() {
		if (!enabled) {
			return;
		}

		if (this.beingHit) {
			this.transform.Rotate(Vector3.forward * Time.fixedDeltaTime * this.animationSpeed);
		}

		if (this.dieDirection != null) {
			this.transform.position += this.dieDirection * Time.fixedDeltaTime * this.dieSpeed;
		}

		if (localTime < cooldown) {
			localTime += Time.fixedDeltaTime;
		}
	}

	void OnTriggerEnter2D() {
		if (this.beingHit) {
			return;
		}

		this.beingHit = true;

		this.GetComponent<HealthController>().Damage(1);
		if (this.GetComponent<HealthController>().health == 0) {
			this.dieDirection = Random.insideUnitCircle.ToVector3();
		}

		StartCoroutine(Extensions.DoAfter(() => {
			this.beingHit = false;
		}, this.animationDuration));
	}

}
