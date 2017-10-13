using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remel.Player {

	[RequireComponent(typeof(PlayerManager))]

	/**
	 * Shitty check ground script. Caches the last three y velocity values and returns
	 * true if norm of all three equal 0.
	 * 
	 * We ideally want something more robust, but this is a simple version that works for now.
	 * Consider changing if ground-checking is messing stuff up.
	 */
	public class PlayerGroundCheck : MonoBehaviour {

		public Vector3 verticalVelocitySeries;

		private PlayerManager playerManager;

		public bool isGrounded;

		// Use this for initialization
		void Start () {
			playerManager = GetComponent<PlayerManager> ();

			verticalVelocitySeries = Vector3.zero;
		}
		
		// Update is called once per frame
		void Update () {
			GroundCheck ();

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
	}

}