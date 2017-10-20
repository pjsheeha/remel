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

	protected int detectionMask;

	void Start () {
		enemyManager = GetComponent<EnemyManager> ();
	}

	void Update () {
		// detect object in sprite, probably wanna do box overlaps in Update() over trigger enter
	}

	protected virtual void OnTriggerEnter2D(Collider2D c) {
		if (c.GetComponent<DetectionMarker> ()) {
			Type t = c.GetComponent<DetectionMarker> ().GetType ();

			if (t == detectionType) {

				Target = c.transform;

				enemyManager.SetDestination (Target.position);

			}

		}

	}

	protected virtual void OnTriggerExit2D(Collider2D c) {
		if (1 << c.gameObject.layer == detectionMask) {
			Target = loseTargetWhenOOR ? null : Target;
		}
	}
}
