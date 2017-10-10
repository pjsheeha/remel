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

	protected bool playerSpotted = false;
	protected float dbTimer = 0f;
	protected float dbInterval = Mathf.Infinity;

	// Use this for initialization
	protected virtual void Start () {
		dbInterval = Random.value * RandomBehaviorTime;

		enemyManager = GetComponent <EnemyManager> ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		dbTimer += Time.deltaTime;

		if (dbTimer >= dbInterval) {
			DefaultBehavior ();

			dbInterval = RandomBehaviorTime;
			dbTimer = 0f;
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
		Vector3 direction = Vector3.right * (Random.value > 0.5f ? 1f : -1f);

		Move (direction, RandomWalkDistance);
	}

	public void Move(Vector3 direction, float distance) {

		float speed = playerSpotted ? moveSpeed : idleSpeed;
		float moveTime = distance / speed;

		enemyManager.rb.velocity = direction * speed;

		enemyManager.SetAnim (playerSpotted ? "chasing" : "moving", true);
		enemyManager.sr.flipX = direction.x > 0f ? true : false;

		StartCoroutine (MoveForSeconds (direction, moveTime));

	}

	protected IEnumerator MoveForSeconds(Vector2 direction, float time) {
		yield return new WaitForSeconds (time);

		enemyManager.rb.velocity = Vector2.zero;

		enemyManager.SetAnim (playerSpotted ? "chasing" : "moving", false);
	}
}
