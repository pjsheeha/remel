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

	public bool CollectedAllEnergy {
		get {
			NegativeEnergyParticle[] negParticles = FindObjectsOfType<NegativeEnergyParticle> ();

			return negParticles.Length == 0;

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

		PlayerManager.Instance.ResumeMovement ();
		PlayerManager.Instance.rb.position = spawnPosition;
	
		SetPlatformColors ();
		SetBackgroundColor ();

	}

}
