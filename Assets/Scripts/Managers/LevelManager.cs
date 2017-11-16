using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Manages level information (i.e. how much energy to move on)
 */
public class LevelManager : Singleton<LevelManager> {

	[SerializeField]
	public Vector2 spawnPosition = Vector2.zero;

	[SerializeField]
	Color platform = new Color (1f, 1f, 1f, 1f),
		underPlatformLeft = new Color (1f, 1f, 1f, 0.7f),
		underPlatformRight = new Color (1f, 1f, 1f, 0.7f),
		underPlatformMid = new Color (1f, 1f, 1f, 0.7f);

	[SerializeField]
	Color backgroundColor = new Color (1f, 1f, 1f, 1f);

	protected void Update() {
		CheckDoorUnlock ();
	}

	public bool CollectedAllEnergy {
		get {
			Key[] keys = FindObjectsOfType<Key> ();

			return keys.Length == 0;

		}
	}

	private void SetPlatformColors() {
		foreach (Platform p in GameObject.FindObjectsOfType<Platform>()) {
			p.SetColors (platform, underPlatformLeft, underPlatformRight, underPlatformMid);
		}
	}

	private void SetBackgroundColor() {
		Camera.main.backgroundColor = backgroundColor;
	}

	protected void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

		// PlayerManager.Instance.ResumeMovement ();
		PlayerManager.Instance.rb.position = spawnPosition;
		PlayerManager.Instance.TriggerAnimation ("open");
		PlayerManager.Instance.ResetTrigger ("exit");
		PlayerManager.Instance.SetInvincible(true);
	
		SetPlatformColors ();
		SetBackgroundColor ();

	}

	public void CheckDoorUnlock() {

		// unlocks door if no more negative energy particles
		int particlesRemaining = GameObject.FindObjectsOfType<Key> ().Length;

		foreach (Key key in GameObject.FindObjectsOfType<Key>()) {
			if (key.Collected) {
				particlesRemaining--;
			}
		}

		// print ("" + particlesRemaining + " particles remaining.");

		if (particlesRemaining == 0) {
			LevelGate.Instance.Unlock ();
		} else {
			LevelGate.Instance.Lock ();
		}
	}

}
