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

	public bool isMoving {
		private set;
		get;
	}

	public Vector2 Displacement {
		private set;
		get;
	}

	protected EnemyManager enemyManager;
	protected Vector2 movementStart;

	protected float dbTimer = 0f;
	protected float dbInterval = Mathf.Infinity;

	protected float moveTimer = 0f;
	protected float moveDuration = 0f;

	// Use this for initialization
	protected virtual void Start () {
		movementStart = transform.position;
		dbInterval = Random.value * RandomBehaviorTime;

		enemyManager = GetComponent <EnemyManager> ();
		enemyManager.SetDestination (movementStart);
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		UpdateMovement ();

		if (enemyManager.TargetSpotted) return;

		dbTimer += Time.deltaTime;

		if (dbTimer >= dbInterval) {
			DefaultBehavior ();

			dbInterval = RandomBehaviorTime;
			dbTimer = 0f;
		}
	}

	protected void UpdateMovement() {
		moveTimer += Time.deltaTime;

		Vector2 newPosition = enemyManager.rb.position;
		newPosition.x = Mathf.Lerp (movementStart.x, enemyManager.Destination.x, moveTimer / moveDuration);

		enemyManager.rb.position = newPosition;

		if (moveTimer / moveDuration >= 1f) {
			moveTimer = moveDuration;
			isMoving = false;
		}
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
		Vector2 direction = Vector2.right * (Random.value > 0.5f ? 1f : -1f);
		Vector2 randomLocation = enemyManager.rb.position + direction * RandomWalkDistance;

		enemyManager.SetDestination (randomLocation);
		// Move (randomLocation);
	}

	public void SetMovement() {

		isMoving = true;

		this.movementStart = transform.position;

		float speed = enemyManager.TargetSpotted ? moveSpeed : idleSpeed;

		Displacement = enemyManager.Destination - enemyManager.rb.position;

		this.moveDuration = Displacement.magnitude / speed;
		this.moveTimer = 0f;
	}

	public void Move(Vector2 location) {

		print (moveTimer);

		isMoving = true;

		enemyManager.SetDestination (location);

		this.movementStart = transform.position;

		float speed = enemyManager.TargetSpotted ? moveSpeed : idleSpeed;

		Displacement = location - enemyManager.rb.position;

		this.moveDuration = Displacement.magnitude / speed;
		this.moveTimer = 0f;


	}

}
