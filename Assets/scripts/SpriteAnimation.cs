using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour {

	public Sprite[] sprites;
	public float period = 0.25f;

	private int currentSprite = 0;
	private float localTime = 0.0f;

	void Start () {
		SetCurrentSprite ();
	}

	void SetCurrentSprite() {
		this.GetComponent<SpriteRenderer> ().sprite = this.sprites[currentSprite];
	}

	void FixedUpdate () {
		localTime += Time.fixedDeltaTime;

		if (localTime > period) {
			this.currentSprite += 1;
			if (currentSprite >= sprites.Length) {
				this.currentSprite = 0;
			}
			SetCurrentSprite ();
			localTime = 0;

		}
	}
}
