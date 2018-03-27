using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {

	public List<RawImage> healthImages;

	void Start() {
		Dogsu.healthController.OnHealthChange += OnHealthChange;
		OnHealthChange (Dogsu.healthController.health);
	}

	void OnHealthChange(int health) {
		for (var i = 0; i < healthImages.Count; i++) {
			healthImages[i].enabled = i < health ? true : false;
		}
	}

}
