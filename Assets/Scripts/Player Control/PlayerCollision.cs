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

	protected void OnTriggerEnter2D(Collider2D c) {
		if (c.transform.GetComponent<Projectile> ()) {
			playerManager.LoseEnergy ();
			Key[] keys = FindObjectsOfType<Key> ();

			foreach (Key key in keys) {
				key.Reset ();
			}

			Rigidbody2D projectileRB = c.transform.GetComponent<Rigidbody2D> ();

			Vector2 playerMomentum = playerManager.rb.velocity * playerManager.rb.mass;
			playerMomentum += projectileRB.velocity * projectileRB.mass;

			playerManager.rb.velocity = playerMomentum / playerManager.rb.mass;
			playerManager.SetInvincible (0.125f);
			playerManager.LoseControl ();
			playerManager.TriggerAnimation ("hit");
		}
	}

	protected void OnCollisionStay2D(Collision2D c) {

		if (playerManager.Invincible) {
			return;
		}

		if (c.transform.GetComponent<EnemyManager> ()) {

			EnemyManager em = c.transform.GetComponent<EnemyManager> ();
				
			playerManager.LoseEnergy ();

			if (!playerManager.Invincible) {
				playerManager.SetInvincible (0.125f);
			}

			Key[] keys = FindObjectsOfType<Key> ();

			foreach (Key key in keys) {
				key.Reset ();
			}

			if (!em.EnableKnockback) {
				return;
			}

			// reflect player's speed
			Vector2 reflectDirection = (playerManager.rb.position - em.rb.position).normalized; // rigidbodies for Vector2 positions
			// playerManager.rb.velocity = reflectDirection * playerManager.Knockback;
			playerManager.rb.AddForce(reflectDirection * playerManager.Knockback, ForceMode2D.Impulse);

			playerManager.LoseControl ();
			playerManager.TriggerAnimation ("hit");
		}
	}
}
