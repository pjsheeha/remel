using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	protected SpriteRenderer sr;
	protected bool collected;

	public bool Collected {
		get {
			return collected;
		}
	}

	void Awake() {
		collected = false;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.GetComponent<PlayerManager> ()) {
			PlayerManager pm = c.GetComponent<PlayerManager> ();

			if (pm.GainEnergy ()) {
				pm.UpdatePlayerColor ();
				pm.TriggerAnimation ("collect");

				// SetVisible (false);
				pm.queueDisappearingKey = this;
				collected = true;
			}
		}
	}

	public void Reset() {
		SetVisible (true);

		collected = false;
	}

	public void SetVisible(bool v) {
		sr.enabled = v;
		GetComponent<Collider2D> ().enabled = v;
	}
}
