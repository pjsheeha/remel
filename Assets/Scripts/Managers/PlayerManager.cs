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

		[SerializeField]
		private Transform t_mouth;

		// player's mouth transform is read-only - can't be tampered with outside
		public Transform mouth {
			get {
				return t_mouth;
			}
		}

		// returns isGrounded from PlayerGroundCheck component
		public bool isGrounded {
			get {
				return groundCheck.isGrounded;
			}
		}

		// returns energy saturation from PlayerEnergyCollector
		public bool isSaturated {
			get {
				return playerEnergy.isSaturated;
			}
		}

		// returns energy level
		public int Energy {
			get {
				return playerEnergy.Energy;
			}
		}

		// let Rigidbody2D be read-only
		public Rigidbody2D rb {
			private set;
			get;
		}

		// ^ same for SpriteRenderer
		public SpriteRenderer spriteRenderer {
			private set;
			get;
		}

		public bool useMovement {
			private set;
			get;
		}

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
			useMovement = true;
		}

		// called whenever something happens to energy level
		// can remove if needed
		public void UpdatePlayerColor() {
			spriteRenderer.color = Color.Lerp (
				Color.white,
				playerEnergy.SaturationColor,
				playerEnergy.Saturation
			);
		}

		// returns true if IncrementEnergy (PlayerEnergyCollector) is successful
		// used in NegativeEnergyParticle to call UpdatePlayerColor() upon collection
		public bool GainEnergy() {
			return playerEnergy.IncrementEnergy ();
		}

		// decrements energy level in PlayerEnergyCollector and updates
		// player color
		public void LoseEnergy () {
			playerEnergy.LoseEnergy ();
			UpdatePlayerColor ();
		}

		// resets the number of jumps in PlayerMovement component
		public void ResetJumps() {
			playerMovement.ResetJumps ();
		}

		// pauses player movement inputs
		public void PauseMovement() {
			useMovement = false;
		}

		// resumes player movement inputs
		public void ResumeMovement() {
			useMovement = true;
		}

		// calls SetBool in the Animator component
		public void SetAnimation(string animationName, bool val) {
			anim.SetBool (animationName, val);
		}

		// calls SetTrigger in the Animator component
		public void TriggerAnimation(string animationName) {
			anim.SetTrigger (animationName);
		}
	}
}