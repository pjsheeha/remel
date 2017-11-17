using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]

/**
 * Shitty check ground script. Caches the last three y velocity values and returns
 * true if norm of all three equal 0.
 * 
 * We ideally want something more robust, but this is a simple version that works for now.
 * Consider changing if ground-checking is messing stuff up.
 */
public class PlayerGroundCheck : MonoBehaviour {

	[SerializeField]
	private Transform groundCheck;

	[SerializeField]
	protected LayerMask[] ignoreLayers;

	public Vector3 verticalVelocitySeries;

	private PlayerManager playerManager;
	private int layerMask;

	public bool isGrounded;

	// Use this for initialization
	void Start () {
		playerManager = GetComponent<PlayerManager> ();

		layerMask = 0;

		foreach (LayerMask lm in ignoreLayers) {
			layerMask = layerMask | lm;
		}

		layerMask = ~layerMask;

		verticalVelocitySeries = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		GroundCheckTwoPointOh ();

		if (isGrounded) {
			playerManager.ResetJumps ();
		}

		playerManager.SetAnimation ("grounded", isGrounded);
	}

	private void GroundCheck() {
		verticalVelocitySeries.x = verticalVelocitySeries.y;
		verticalVelocitySeries.y = verticalVelocitySeries.z;

		verticalVelocitySeries.z = playerManager.rb.velocity.y;

		isGrounded = verticalVelocitySeries.magnitude == 0f;
	}

	private void GroundCheckTwoPointOh() {
		Collider2D c = Physics2D.OverlapBox (groundCheck.position, new Vector2 (GetComponent<BoxCollider2D>().size.x, 1e-5f), 0f, layerMask);

		isGrounded = c != null && !c.transform.GetComponent<Collider2D>().isTrigger;
	}
}
