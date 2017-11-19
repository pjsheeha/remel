using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	public static float KEY_RETURN_SPEED = 5f;

	protected SpriteRenderer sr;
	protected bool collected;

	private Vector3 startPosition;

	public bool Collected {
		get {
			return collected;
		}
	}

	void Awake() {
		collected = false;
		sr = GetComponent<SpriteRenderer> ();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Lerp (transform.position, startPosition, Time.deltaTime * KEY_RETURN_SPEED);

		if (sr.enabled && (transform.position - startPosition).magnitude <= 0.1f) {
			SetCollectible (true);
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.GetComponent<PlayerManager> ()) {
			PlayerManager pm = c.GetComponent<PlayerManager> ();

			if (pm.GainEnergy ()) {
				pm.UpdatePlayerColor ();
				pm.TriggerAnimation ("collect");

				// SetVisible (false);
				pm.queueDisappearingKey = this;
			}
		}
	}

	public void Reset() {
		SetVisible (true);

		if (collected) {
			transform.position = PlayerManager.Instance.rb.position;
		}
	}

	public void SetVisible(bool v) {
		sr.enabled = v;
	}

	public void SetCollectible(bool v) {
		GetComponent<Collider2D> ().enabled = v;

		collected = !v;
	}
}
