using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;
using Remel.Utilities;

namespace Remel.Player {

	/**
	 * This class organizes information from the other player classes into a single manager singleton.
	 * This will help data flow between components by keeping track of relevant data in just one component.
	 */
	public class PlayerManager : PersistentSingleton<PlayerManager> {

		public Transform mouth;

		public bool isGrounded {
			get {
				return groundCheck.isGrounded;
			}
		}

		public bool isSaturated {
			get {
				return playerEnergy.isSaturated;
			}
		}

		public int Energy {
			get {
				return playerEnergy.Energy;
			}
		}

		public Rigidbody2D rb {
			get;
			set;
		}
		public SpriteRenderer spriteRenderer {
			get;
			set;
		}

		public bool useMovement = true;

		private PlayerMovement playerMovement;
		private PlayerGroundCheck groundCheck;
		private PlayerEnergyCollector playerEnergy;

		private Animator anim;

		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator> ();
			groundCheck = GetComponent<PlayerGroundCheck> ();
			playerEnergy = GetComponent<PlayerEnergyCollector> ();
			playerMovement = GetComponent<PlayerMovement> ();
			rb = GetComponent<Rigidbody2D> ();
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}
		
		public void UpdatePlayerColor() {
			spriteRenderer.color = Color.Lerp (
				Color.white,
				playerEnergy.SaturationColor,
				playerEnergy.Saturation
			);
		}

		public bool GainEnergy() {
			return playerEnergy.IncrementEnergy ();
		}

		public void LoseEnergy () {
			playerEnergy.LoseEnergy ();
			UpdatePlayerColor ();
		}

		public void ResetJumps() {
			playerMovement.ResetJumps ();
		}

		public void PauseMovement() {
			useMovement = false;
		}

		public void ResumeMovement() {
			useMovement = true;
		}

		public void SetAnimation(string animationName, bool val) {
			anim.SetBool (animationName, val);
		}

		public void TriggerAnimation(string animationName) {
			anim.SetTrigger (animationName);
		}
	}
}