using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

	[SerializeField]
	protected Transform firePoint;
	[SerializeField]
	protected GameObject laser;

	private EnemyManager enemyManager;

	// Use this for initialization
	void Start () {
		enemyManager = GetComponent<EnemyManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h_Input = Input.GetAxis ("Horizontal");

		if (h_Input != 0f) {
			enemyManager.sr.flipX = enemyManager.SpriteLeftByDefault ? (h_Input > 0f ? false : true) : (h_Input > 0f ? true : false);
			enemyManager.TriggerAnim ("fire");
		} else {
			enemyManager.ResetTrigger ("fire");
		}
	}

	public void Shoot() {
		Vector2 enemyDirection = Vector2.right * (enemyManager.sr.flipX ? -1f : 1f) * (enemyManager.SpriteLeftByDefault ? 1f : -1f);
		SoundManager.instance.PlaySound ("pop");

		Instantiate<GameObject> (
			laser, 
			firePoint.position, 
			Quaternion.Euler(new Vector3(0f, 0f, enemyDirection.x == 1f ? 0f : 180f))
		);
	}
}
