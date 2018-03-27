using System;
using UnityEngine;
using System.Collections;

public static class Extensions {

	public static IEnumerator DoAfter(Action action, float seconds) {
		yield return new WaitForSeconds(seconds);
		action ();
	}

	public static Vector3 ToVector3(this Vector2 v) {
		return new Vector3(v.x, v.y, 0);
	}

}
