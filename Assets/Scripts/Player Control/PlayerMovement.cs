using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	protected float moveSpeed = 2.0f;
	[SerializeField]
	protected float jumpHeight = 4.0f;
	[SerializeField]
	protected int numJumps = 5;

	public Animator anim;

	private BoxCollider2D coll;
	private PlayerGroundCheck playerGroundCheck;
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	private float h_Input;
	private int remainingJumps;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		coll = GetComponent<BoxCollider2D> ();
		playerGroundCheck = GetComponent<PlayerGroundCheck> ();
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();

		remainingJumps = numJumps;
	}
	
	// Update is called once per frame
	void Update () {
		HorizontalMovement ();
		Jump ();
	}

	private void HorizontalMovement() {
		h_Input = Input.GetAxis ("Horizontal");

		rb.transform.position += Vector3.right * h_Input * Time.deltaTime * moveSpeed;

		anim.SetBool ("walk", Mathf.Abs(h_Input) > 0f);

		sr.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : sr.flipX;
	}

	private void Jump() {
		if (Input.GetKeyDown (KeyCode.UpArrow) && remainingJumps > 0) {
			Vector2 vel = rb.velocity;
			vel.y = jumpHeight * remainingJumps-- / numJumps;

			rb.velocity = vel;

			anim.SetBool ("grounded", false);

			if (playerGroundCheck.isGrounded) {
				anim.SetTrigger ("jump");
				anim.ResetTrigger ("air_jump");
			} else {
				anim.SetTrigger ("air_jump");
				anim.ResetTrigger ("jump");
			}
		}
	}

	public void ResetJumps() {
		remainingJumps = numJumps;
	}
}
