using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	private EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
		enemyManager = GetComponent<EnemyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool DetectionCollision(Vector2 position) {

		int enemyLayer = 1 << LayerMask.NameToLayer ("Enemy") | 1 << LayerMask.NameToLayer ("Gate");

		enemyLayer = ~(enemyLayer);

		Vector2 dir = position - enemyManager.rb.position;

		RaycastHit2D hit = Physics2D.Raycast (enemyManager.rb.position + Vector2.up * enemyManager.sr.size.y / 2, dir, dir.magnitude, enemyLayer);

		// return false if nothing is hit or player is hit

		if (!hit || hit.transform.GetComponent<PlayerManager> ()) {
			return false;
		}

		return true;
	}
}
