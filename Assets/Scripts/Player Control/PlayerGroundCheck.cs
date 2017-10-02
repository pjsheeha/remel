using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remel.Player {

	[RequireComponent(typeof(PlayerManager))]

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