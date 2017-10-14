using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyManager : MonoBehaviour {

	public Rigidbody2D rb {
		private set;
		get;
	}

	public SpriteRenderer sr {
		private set;
		get;
	}

	public Animator anim {
		private set;
		get;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetAnim(string animation, bool value) {
		anim.SetBool (animation, value);
	}
}
