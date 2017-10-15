using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	protected float idleSpeed = 1f;

	[SerializeField]
	protected float moveSpeed = 6f;

	// set random walk interval
	[SerializeField]
	protected Vector2 randomWalkInterval = new Vector2 (2f, 4f);
	[SerializeField]
	protected Vector2 randomWalkDistance = new Vector2 (1f, 2f);

	protected EnemyManager enemyManager;
	protected Vector2 movementStart;

	protected float dbTimer = 0f;
	protected float dbInterval = Mathf.Infinity;

	protected float moveTimer = 0f;
	protected float moveDuration = 0f;

	// Use this for initialization
	protected virtual void Start () {
		print (transform.position);
		movementStart = transform.position;
		dbInterval = Random.value * RandomBehaviorTime;

		enemyManager = GetComponent <EnemyManager> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		MoveToTarget ();

		if (enemyManager.TargetSpotted) return;

		dbTimer += Time.deltaTime;

		if (dbTimer >= dbInterval) {
			DefaultBehavior ();

			dbInterval = RandomBehaviorTime;
			dbTimer = 0f;
		}
	}

	private void MoveToTarget() {
		Vector2 target = enemyManager.Target;

		moveTimer += Time.deltaTime;

		enemyManager.rb.position = Vector2.Lerp (movementStart, enemyManager.Target, moveTimer / moveDuration);
	}

	// default behavior can be overwritten in extension scripts
	protected virtual void DefaultBehavior () {
		RandomMove ();
	}

	protected float RandomBehaviorTime {
		get {
			return Random.value * (randomWalkInterval.y - randomWalkInterval.x) + randomWalkInterval.x;
		}
	}

	protected float RandomWalkDistance {
		get {
			return Random.value * (randomWalkDistance.y - randomWalkDistance.x) + randomWalkDistance.x;
		}
	}

	public void RandomMove() {
		Vector3 direction = Vector3.right * (Random.value > 0.5f ? 1f : -1f);

		Move (direction, RandomWalkDistance);
	}

	public void Move(Vector3 direction, float distance) {

		this.movementStart = transform.position;

		float speed = enemyManager.TargetSpotted ? moveSpeed : idleSpeed;

		enemyManager.SetTarget (direction * distance);

		this.moveDuration = distance / speed;
		this.moveTimer = 0f;

		enemyManager.SetAnim (enemyManager.TargetSpotted ? "chasing" : "moving", true);
		enemyManager.sr.flipX = direction.x > 0f ? true : false;

	}

	public void Move(Vector3 target) {
		Vector2 direction = target - transform.position;
		direction.y = 0f;

		float distance = direction.magnitude;
		direction.Normalize ();

		Move (direction, distance);
	}

}
