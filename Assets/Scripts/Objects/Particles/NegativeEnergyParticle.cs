using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEnergyParticle : EnergyParticle {

	public bool Collected {
		get {
			return collected;
		}
	}

	protected bool collected;

	protected void Awake() {
		collected = false;
	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.GetComponent<PlayerManager> ()) {
			PlayerManager pm = c.GetComponent<PlayerManager> ();

			if (pm.GainEnergy ()) {
				pm.UpdatePlayerColor ();

				partSys.Stop ();

				GetComponent<CircleCollider2D> ().enabled = false;
				collected = true;
			}
		}
	}

	public override void Reset() {
		base.Reset ();

		collected = false;
	}
}
