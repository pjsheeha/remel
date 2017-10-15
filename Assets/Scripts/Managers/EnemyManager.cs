using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyDetection))]
[RequireComponent(typeof(EnemyMovement))]

public class EnemyManager : MonoBehaviour {

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

	public Vector2 Target {
		private set;
		get;
	}

	protected EnemyDetection enemyDetection;
	protected EnemyMovement enemyMovement;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();

		enemyDetection = GetComponent<EnemyDetection> ();
		enemyMovement = GetComponent<EnemyMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTarget(Vector2 target) {
		Target = target;
	}

	public void SetAnim(string animation, bool value) {
		anim.SetBool (animation, value);
	}

	public void TriggerAnim(string animation) {
		anim.SetTrigger (animation);
	}
}
