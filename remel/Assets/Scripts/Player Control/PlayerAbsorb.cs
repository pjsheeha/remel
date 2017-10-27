using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;
using Remel.Objects;

namespace Remel.Player {

	[RequireComponent (typeof(PlayerManager))]

	/**
	 * PlayerAbsorb class checks for player input (Space bar) to initiate absorption
	 * of negative energy particles.
	 */
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

		// absorption should be framerate invariant
		void FixedUpdate() {
			Absorb ();
		}

		// checks for key press and toggles 'absorption' boolean
		// also toggles pause/resume movement in PlayerManager component
		private void CheckInitiate() {

			// absorption is true if key pressed and neg-energy isn't saturated (PlayerEnergyCollector)
			absorption = Input.GetKey (KeyCode.Space) && !playerManager.isSaturated;

			playerManager.SetAnimation ("sucking", absorption);

			if (Input.GetKeyDown (KeyCode.Space) && absorption) {
				playerManager.PauseMovement ();
			} else if (Input.GetKeyUp (KeyCode.Space) && !absorption) {
				playerManager.ResumeMovement ();
			}
		}

		// called in FixedUpdate for Physics update
		// applies force on neg-energy particles inversely proportional to the distance
		// squared between player and each particle
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