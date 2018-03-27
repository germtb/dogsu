using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnPause : MonoBehaviour {

	void Start () {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}

		GameController.Instance.onPause += OnPause;
		GameController.Instance.onUnpause += OnUnpause;
	}

	void OnPause() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (true);
		}
	}

	void OnUnpause() {
		foreach (Transform child in transform) {
			child.gameObject.SetActive (false);
		}
	}

}
