﻿using System.Collections;
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

			EnemyManager em = c.transform.GetComponent<EnemyManager> ();
				
			playerManager.LoseEnergy ();

			Key[] keys = FindObjectsOfType<Key> ();

			foreach (Key key in keys) {
				key.Reset ();
			}

			if (!em.EnableKnockback) {
				return;
			}

			// reflect player's speed
			Vector2 reflectDirection = (playerManager.rb.position - em.rb.position).normalized; // rigidbodies for Vector2 positions
			playerManager.rb.velocity = reflectDirection * playerManager.Knockback;

			playerManager.LoseControl (playerManager.KnockbackTime);
		}
	}
}