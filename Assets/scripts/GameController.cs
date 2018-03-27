using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Level {
	Menu,
	Level1
}

public class GameController : MonoBehaviour {

	public Action onPause;
	public Action onUnpause;
	public Level currentLevel;

	private bool paused = false;

	public static GameController Instance;

	void Awake() {
		GameController.Instance = this;
		Time.timeScale = 1f;
	}

	void Start() {
		if (Dogsu.healthController != null) {
			Dogsu.healthController.OnDie += () =>
				StartCoroutine(
					Extensions.DoAfter(
						LoadMenu,
						2f
					)
				);
		}
	}

	public void LoadLevel1() {
		SceneManager.LoadScene("Level1", LoadSceneMode.Single);
	}

	public void LoadMenu() {
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void PauseGame() {
		Time.timeScale = 0f;
		this.paused = true;
		if (onPause != null) {
			onPause();
		}
	}

	public void UnpauseGame() {
		Time.timeScale = 1f;
		this.paused = false;
		if (onUnpause != null) {
			onUnpause();
		}
	}

	public void LooseGame() {

	}

	void Update() {
		if (this.currentLevel == Level.Menu) {
			return;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (this.paused) {
				this.UnpauseGame();
			} else {
				this.PauseGame();
			}
		}
	}
}
