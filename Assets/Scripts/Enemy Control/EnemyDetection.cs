using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DetectionType {
	PlayerMarker,
	Footstep
}

public class EnemyDetection : MonoBehaviour {

	[SerializeField]
	protected DetectionType detection;
	[SerializeField]
	protected float detectionRadius = 2f;
	[SerializeField]
	protected bool loseTargetWhenOOR = true;

	public Transform Target {
		protected set;
		get;
	}

	public Type detectionType {
		get {
			return Type.GetType (detection.ToString ());
		}
	}

	protected EnemyManager enemyManager;
	protected Transform target;

	protected int detectionMask;

	void Start () {
		enemyManager = GetComponent<EnemyManager> ();
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
}
