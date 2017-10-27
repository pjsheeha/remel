using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField]
	protected float speed = 15f;
	[SerializeField]
	protected float range = 15f;
	[SerializeField]
	protected bool destroyOnTouch = true;

	private float ttl;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		ttl = range / speed;

		Destroy (gameObject, ttl);
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = -transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (!destroyOnTouch) {
			return;
		}

		if (c.transform.tag != "Player") {
			Destroy (gameObject);
		}
	}
}
