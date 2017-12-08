using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(PlayerManager))]

/**
 * Processes player horizontal movement and jumping. Movement script is
 * independent of sprite animations as long as the sprite's animator contains params
 */
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	protected float moveSpeed = 2.0f;
	[SerializeField]
	protected float jumpHeight = 4.0f;
	[SerializeField]
	protected int numJumps = 5;
	private int timer = 0;
	public bool isMoving {
		get {
			return this.h_Input != 0f;
		}
	}

	private PlayerManager playerManager;

	private float h_Input;
	private int remainingJumps;

	// Use this for initialization
	void Start () {
		playerManager = GetComponent<PlayerManager> ();

		remainingJumps = numJumps;
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;
		HorizontalMovement ();
		Jump ();
	}

	private void HorizontalMovement() {
		h_Input = playerManager.useMovement ? Input.GetAxis ("Horizontal") :  0f;

		// use rigidbody position instead of transform to eliminate jitter when colliding with walls
		playerManager.rb.position += Vector2.right * h_Input * Time.deltaTime * moveSpeed;

		playerManager.SetAnimation ("walk", Mathf.Abs(h_Input) > 0f);

		if (timer % 30 == 1 && h_Input==1 && playerManager.isGrounded) {
			SoundManager.instance.PlaySound ("footstep-1");
		}
		if (timer % 30 == 1 && h_Input==-1 && playerManager.isGrounded) {
			SoundManager.instance.PlaySound ("footstep-2");
		}

		playerManager.spriteRenderer.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : playerManager.spriteRenderer.flipX;
	}

	private void Jump() {
		if (GetComponent<JumpReplacement> () || !playerManager.useMovement) {
			return;
		}

		if ((Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && remainingJumps > 0) {
			Vector2 vel = playerManager.rb.velocity;
			vel.y = jumpHeight * remainingJumps-- / numJumps;

			playerManager.rb.velocity = vel;

			playerManager.SetAnimation ("grounded", false);

			playerManager.TriggerAnimation ("jump");
			print (remainingJumps);
			if (remainingJumps <1) {
				SoundManager.instance.PlaySound ("jump");
			}
			else if (remainingJumps <3) {
				SoundManager.instance.PlaySound ("jump2");
			}
			else if (remainingJumps<=4) {
				SoundManager.instance.PlaySound ("jump3");
			}
		
		}
	}

	public void ResetJumps() {
		remainingJumps = numJumps;
	}

	public void ResetPosition() {
		playerManager.rb.position = LevelManager.Instance.spawnPosition;
		playerManager.rb.velocity = Vector2.zero;
	}
}
