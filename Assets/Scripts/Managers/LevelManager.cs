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

	public bool CollectedAllEnergy {
		get {
			NegativeEnergyParticle[] negParticles = FindObjectsOfType<NegativeEnergyParticle> ();

			return negParticles.Length == 0;
		}
	}

	protected void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	protected void OnSceneLoaded(Scene scene, LoadSceneMode mode) {

		PlayerManager.Instance.ResumeMovement ();
		PlayerManager.Instance.rb.position = spawnPosition;
	
	}

}