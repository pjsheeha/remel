using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]

public class PlayerFootsteps : MonoBehaviour {

	[SerializeField]
	protected GameObject footstepPrefab;
	[SerializeField]
	protected float footstepInterval = 0.5f;

	private PlayerManager playerManager;

	private float footstepTimer;

	// Use this for initialization
	void Start () {
		playerManager = GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		SpawnFootsteps ();
	}

	private void SpawnFootsteps() {
		footstepTimer += Time.deltaTime;

		if (footstepTimer >= footstepInterval) {

			footstepTimer = footstepInterval;

			if (playerManager.isGrounded) {
				// Spawn footstep object if rb velocity is non-zero
				GameObject footstep = Instantiate<GameObject> (footstepPrefab.gameObject, transform.position, Quaternion.identity);

				Collider2D[] cs = Physics2D.OverlapCircleAll (footstep.transform.position, footstep.GetComponent<CircleCollider2D> ().radius);

				foreach (Collider2D c in cs) {
					if (c.gameObject != footstep && c.GetComponent<Footstep> ()) {
						Destroy (footstep);
					}
				}

				// Reset footstep timer
				footstepTimer = 0f;
			}
		}
	}
}
