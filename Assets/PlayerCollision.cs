using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]

public class PlayerCollision : MonoBehaviour {

	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		playerManager = GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnCollisionEnter2D(Collision2D c) {
		if (c.transform.GetComponent<EnemyManager> ()) {

			playerManager.rb.AddForce (c.contacts [0].normal * playerManager.Knockback, ForceMode2D.Impulse);

			playerManager.LoseControl (playerManager.KnockbackTime);
			playerManager.LoseEnergy ();

			NegativeEnergyParticle[] negEnergies = FindObjectsOfType<NegativeEnergyParticle> ();

			foreach (NegativeEnergyParticle negEnergy in negEnergies) {
				negEnergy.Reset ();
			}
		}
	}
}
