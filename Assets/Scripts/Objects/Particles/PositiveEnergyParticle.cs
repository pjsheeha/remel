﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveEnergyParticle : EnergyParticle {

	protected override void Start () {
		base.Start ();
	}

	protected void Update() {
		if (GetComponent<Rigidbody2D> ().velocity.magnitude < 1e-1) {
			Destroy (gameObject);
		}
	}

}
