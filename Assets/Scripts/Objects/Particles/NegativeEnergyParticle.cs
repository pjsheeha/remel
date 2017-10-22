using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEnergyParticle : EnergyParticle {

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
			}
		}
	}
}
