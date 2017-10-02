using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;

namespace Player {

	[RequireComponent (typeof(PlayerManager))]

	public class PlayerAbsorb : MonoBehaviour {

		[SerializeField]
		protected float absorptionPower = 10f;

		private PlayerManager playerManager;

		private bool absorption = false;

		// Use this for initialization
		void Start () {
			playerManager = GetComponent<PlayerManager> ();
		}

		// Update is called once per frame
		void Update () {
			CheckInitiate ();
		}

		void FixedUpdate() {
			Absorb ();
		}

		private void CheckInitiate() {
			if (!playerManager.isGrounded) {
				return;
			}

			absorption = Input.GetKey (KeyCode.Space) && !playerManager.isSaturated;

			playerManager.SetAnimation ("sucking", absorption);

			if (Input.GetKeyDown (KeyCode.Space) && absorption) {
				playerManager.PauseMovement ();
			} else if (Input.GetKeyUp (KeyCode.Space) && !absorption) {
				playerManager.ResumeMovement ();
			}
		}

		private void Absorb() {
			if (!absorption) {
				return;
			}

			NegativeEnergyParticle[] negParticles = FindObjectsOfType<NegativeEnergyParticle> ();

			foreach (NegativeEnergyParticle neg in negParticles) {
				Vector2 dist = transform.position - neg.transform.position;
				neg.GetComponent<Rigidbody2D> ().AddForce (dist.normalized * absorptionPower / Mathf.Max (Mathf.Pow (dist.magnitude, 2f), 1f), ForceMode2D.Force);
			}
		}
	}
}