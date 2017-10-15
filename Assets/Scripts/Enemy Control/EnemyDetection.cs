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
	[SerializeField]
	protected bool loseTargetWhenOOR = true;

	public Transform Target {
		protected set;
		get;
	}

	protected EnemyManager enemyManager;
	protected Transform target;

	protected int detectionMask;

	void Start () {
		enemyManager = GetComponent<EnemyManager> ();

		UpdateDetectionMask ();
	}

	protected virtual void OnTriggerEnter2D(Collider2D c) {
		if (1 << c.gameObject.layer == detectionMask) {
			target = c.transform;

			enemyManager.SetTarget (target.position);
		}
	}

	protected virtual void OnTriggerExit2D(Collider2D c) {
		if (1 << c.gameObject.layer == detectionMask) {
			target = loseTargetWhenOOR ? null : target;
		}
	}

	protected void UpdateDetectionMask() {
		detectionMask = detectionType == DetectionType.PlayerSprite ? 1 << LayerMask.NameToLayer ("Player") : 1 << LayerMask.NameToLayer ("Footstep");
	}
}
