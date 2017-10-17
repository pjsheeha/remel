using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : DetectionMarker {

	[SerializeField]
	protected float lifeTime = 10f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnTriggerEnter2D(Collider2D c) {
		if (c.GetComponent<EnemyManager> ()) {
			EnemyManager em = c.GetComponent<EnemyManager> ();

			if (em.SameDetectionType (this)) {
				em.OnDetection ();
			}

		}
	}

}
