using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remel.Player {

	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(PlayerMovement))]

	public class PlayerGroundCheck : MonoBehaviour {

		public Vector3 verticalVelocitySeries;

		private Rigidbody2D rb;
		private PlayerMovement playerMovement;

		public bool isGrounded;

		// Use this for initialization
		void Start () {
			playerMovement = GetComponent<PlayerMovement> ();
			rb = GetComponent<Rigidbody2D> ();

			verticalVelocitySeries = Vector3.zero;
		}
		
		// Update is called once per frame
		void Update () {
			GroundCheck ();

			if (isGrounded) {
				playerMovement.ResetJumps ();
			}

			playerMovement.anim.SetBool ("grounded", isGrounded);
		}

		private void GroundCheck() {
			verticalVelocitySeries.x = verticalVelocitySeries.y;
			verticalVelocitySeries.y = verticalVelocitySeries.z;

			verticalVelocitySeries.z = rb.velocity.y;

			isGrounded = verticalVelocitySeries.magnitude == 0f;
		}
	}

}