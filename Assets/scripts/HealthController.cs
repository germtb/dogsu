using UnityEngine;
using System;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int maxHelth;
	public int health;

	public Action<int> OnHealthChange;
	public Action OnDie;

	public void Damage(int amount) {
		health -= amount;
		if (OnHealthChange != null) {
			OnHealthChange (health);
		}

		if (health <= 0) {
			health = 0;
			if (OnDie != null) {
				OnDie ();
			}
			OnHealthChange = null;
		}
	}
}
