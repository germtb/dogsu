using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioClip hitSound;
	public AudioClip dieSound;

	void Start () {
		Dogsu.healthController.OnHealthChange += PlayHitSound;
	}

	void PlayHitSound(int health) {
		if (health > 0) {
			this.GetComponent<AudioSource> ().PlayOneShot (hitSound);
		} else {
			this.GetComponent<AudioSource> ().PlayOneShot (dieSound);
		}
	}
}
