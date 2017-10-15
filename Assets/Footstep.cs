using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

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
		
	}
}
