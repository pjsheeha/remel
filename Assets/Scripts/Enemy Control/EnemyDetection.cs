using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DetectionType {
	PlayerMarker,
	Footstep
}

public enum DetectionMethod {
	Bidirectional,
	Unidirectional
}

public enum DetectionShape {
	Circle,
	Rectangle
}

public class EnemyDetection : MonoBehaviour {

	[SerializeField]
	protected DetectionType detection;
	[SerializeField]
	protected DetectionMethod detectionMethod;
	[SerializeField]
	protected bool loseTargetWhenOOR = true;
	[SerializeField]
	protected float detectionSize = 5f;

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

		Collider2D[] overlaps = Detect ();

		// overlaps = Physics2D.OverlapBoxAll (enemyManager.rb.position, new Vector2 (detectionSize, enemyManager.sr.size.y), 0f);

		foreach (Collider2D c in overlaps) {
			if (Target == null && c.GetComponent<DetectionMarker> () && c.GetComponent<DetectionMarker> ().GetType () == detectionType) {

				Target = c.transform;

				enemyManager.SetDestination (Target.position);

				break;

			}
		}

		if (GetComponent<EyeballMovement> ()) {
			print (Target);
		}

		overlaps = Detect ();

		if (!loseTargetWhenOOR) {
			return;
		}

		bool targetFound = false;

		foreach (Collider2D c in overlaps) {
			if (c.GetComponent<DetectionMarker> () && c.GetComponent<DetectionMarker> ().GetType () == detectionType) {
				targetFound = true;
			}
		}

		if (!targetFound) {
			Target = null;
		}

		// implementation using BoxCast in two directions
	}

	protected Collider2D[] Detect () {
		if (detectionMethod == DetectionMethod.Bidirectional) {
			return Physics2D.OverlapBoxAll (enemyManager.rb.position, new Vector2 (detectionSize, enemyManager.sr.size.y), 0f);
		} else {
			Vector2 enemyDirection = (Vector2.right * (enemyManager.sr.flipX ? -1f : 1f)) * (enemyManager.SpriteLeftByDefault ? -1f : 1f);
			return Physics2D.OverlapBoxAll(
				enemyManager.rb.position + Vector2.up * enemyManager.sr.size.y / 2f + enemyDirection * detectionSize / 2f,
				new Vector2(detectionSize, enemyManager.sr.size.y),
				0f
			);
		}
	}

	/*
	protected virtual void OnTriggerEnter2D(Collider2D c) {
		return;
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
	}*/
}
