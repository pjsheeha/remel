using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Remel.Player;

public class Blob : MonoBehaviour {

	[SerializeField]
	protected float sizeChangeSpeed = 1f;
	[SerializeField]
	protected float dist_ground= 0f;
	[SerializeField]
	protected Vector2 sizeLimits = new Vector2(0.4f, 1.2f);

	public bool isInAir = false;

	private EnemyManager enemyManager;
	private SpriteRenderer sr;

	private float h_Input;
	private float transamt = 1;

	// Use this for initialization
	void Start () {
		enemyManager = GetComponent<EnemyManager> ();
		sr = GetComponent<SpriteRenderer> ();
		dist_ground = transform.localScale.y / 2;
	}
	
	// Update is called once per frame
	void Update () {
		h_Input = Input.GetAxis ("Horizontal");

		ChangeSizeOnMovement (h_Input);
	}

	protected void ChangeSizeOnMovement(float horizontal) {
		if (!isInAir) {
			dist_ground = transform.localScale.y / 2;
			// transform.localPosition = new Vector3(transform.localPosition.x, dist_ground, transform.localPosition.z);
			transform.localScale += Vector3.one * horizontal * sizeChangeSpeed * Time.deltaTime;

			enemyManager.SetAnim ("compress", horizontal < 0f);
			enemyManager.SetAnim ("expand", horizontal > 0f);

			if (transform.localScale [0] < sizeLimits.x)
				transform.localScale = Vector3.one * sizeLimits.x;

			else if (transform.localScale [0] > sizeLimits.y)
				transform.localScale = Vector3.one * sizeLimits.y;
		}

	}

	protected void OnCollisionEnter2D(Collision2D c) {
		if (c.transform.GetComponent<PlayerMarker> ()) {
			Vector2 hitVector = c.contacts [0].point - GetComponent<Rigidbody2D> ().position;

			if (Mathf.Abs (hitVector.y) > 0.5f) {
				enemyManager.TriggerAnim ("top_impact");
			} else {
				enemyManager.TriggerAnim ("side_impact");
			}
		}
	}
}
