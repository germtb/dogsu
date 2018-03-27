using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogsu : MonoBehaviour {

	public static HealthController healthController;

	void Awake() {
		Dogsu.healthController = this.GetComponent<HealthController>();
	}
}
