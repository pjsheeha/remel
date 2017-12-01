using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abyss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void OnTriggerEnter2D(Collider2D c) {
		if (c.transform.GetComponent<PlayerManager> ()) {
			PlayerManager pm = c.transform.GetComponent<PlayerManager> ();
			pm.Respawn ();
		}

		if (c.transform.GetComponent<EnemyManager> ()) {
			EnemyManager em = c.transform.GetComponent<EnemyManager> ();
			// em.Respawn ();
		}

	}
}
