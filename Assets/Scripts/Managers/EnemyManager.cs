using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyDetection))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyCollision))]

public class EnemyManager : MonoBehaviour {

	[SerializeField]
	protected bool spriteLeftByDefault = false;
	[SerializeField]
	protected bool enableKnockback = true;

	public bool EnableKnockback {
		get {
			return this.enableKnockback;
		}
	}

	public bool SpriteLeftByDefault {
		get {
			return this.spriteLeftByDefault;
		}
	}

	public bool isMoving {
		get {
			return enemyMovement.isMoving;
		}
	}

	public Rigidbody2D rb {
		private set;
		get;
	}

	public SpriteRenderer sr {
		private set;
		get;
	}

	public Animator anim {
		private set;
		get;
	}

	public bool TargetSpotted {
		get {
			return enemyDetection.Target != null;
		}
	}

	public Transform Target {
		get {
			return enemyDetection.Target;
		}
	}

	public Vector2 Destination {
		private set;
		get;
	}

	public Type DetectionType {
		get {
			return enemyDetection.detectionType;
		}
	}

	public Action onDetection;

	protected EnemyDetection enemyDetection;
	protected EnemyMovement enemyMovement;
	protected EnemyCollision enemyCollision;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();

		enemyDetection = GetComponent<EnemyDetection> ();
		enemyMovement = GetComponent<EnemyMovement> ();
		enemyCollision = GetComponent<EnemyCollision> ();
	}
	
	// Update is called once per frame
	void Update () {
		Animate ();
	}

	private void Animate() {
		SetAnim (TargetSpotted ? "chasing" : "walking", true);
		SetAnim (TargetSpotted ? "walking" : "chasing", false);

		SetAnim ("moving", isMoving);

		sr.flipX = enemyMovement.Displacement.x > 0f ? (spriteLeftByDefault ? true : false) : (spriteLeftByDefault ? false : true);
	}

	public void FollowTarget() {
		Destination = Target.position;
	}

	public void SetDestination(Vector2 dest) {
		Destination = dest;

		if (enemyMovement) {
			enemyMovement.SetMovement ();
		}
	}

	public bool DetectCollision(Vector2 position) {
		if (enemyCollision == null) {
			return false;
		}

		return enemyCollision.DetectionCollision (position);
	}

	public void SetAnim(string animation, bool value) {
		if (!anim.runtimeAnimatorController) {
			return;
		}
		anim.SetBool (animation, value);
	}

	public void TriggerAnim(string animation) {
		anim.SetTrigger (animation);
	}

	public bool SameDetectionType(DetectionMarker dm) {
		return dm.GetType () == DetectionType;
	}

	public void OnDetection() {
		if (onDetection != null) {
			onDetection ();
		}
	}
}
