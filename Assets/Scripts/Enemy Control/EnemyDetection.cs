using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DetectionType {
	PlayerSprite,
	PlayerFootsteps
}

public class EnemyDetection : MonoBehaviour {

	[SerializeField]
	protected DetectionType detectionType;
	[SerializeField]
	protected float detectionRadius = 2f;

	protected EnemyManager enemyManager;
	protected int detectionMask;

	void Start () {
		enemyManager = GetComponent<EnemyManager> ();

		UpdateDetectionMask ();
	}
	
	void FixedUpdate () {
		Collider2D c = Physics2D.OverlapCircle (transform.position, detectionRadius, detectionMask);

		if (c) {
			if (!enemyManager.anim.GetBool ("chasing")) {
				enemyManager.SetAnim ("chasing", true);
			}
		} else {
			enemyManager.SetAnim ("chasing", false);
		}
	}

	protected void UpdateDetectionMask() {
		detectionMask = detectionType == DetectionType.PlayerSprite ? 1 << LayerMask.NameToLayer ("Player") : 1 << LayerMask.NameToLayer ("Footstep");
	}
}
