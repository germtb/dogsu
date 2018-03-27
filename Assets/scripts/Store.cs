using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Store : MonoBehaviour {
	// public static Store Instance = new Store();
	//
	// private Action<Dictionary<String, string>> listeners;
	// private Dictionary<String, String> state = new Dictionary<string, string>();
	// private List<Func<Dictionary<String, String>, String, String, Dictionary<String, String>>> reducers = new List<>();
	//
	// public void AddReducer(Func<Dictionary<String, String>, String, String, Dictionary<String, String>> reducer) {
	// 	reducers.Add (reducer);
	// }
	//
	// public void Subscribe(Action<Dictionary<string, string>> listener) {
	// 	this.listeners += listener;
	// }
	//
	// public void Unsubscribe(Action<Dictionary<string, string>> listener) {
	// 	this.listeners -= listener;
	// }
	//
	// public void Dispatch(string type, string payload) {
	// 	reducers.ForEach (r => {
	// 		this.state = r(this.state, type, payload);
	// 	});
	//
	// 	listeners (this.state);
	// }
}
