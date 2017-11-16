using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This class organizes information from the other player classes into a single manager singleton.
 * This will help data flow between components by keeping track of relevant data in just one component.
 */
public class PlayerManager : PersistentSingleton<PlayerManager> {

	[SerializeField]
	protected float invincibilityDuration = 2f;
	[SerializeField]
	protected float knockback = 8f;
	[SerializeField]
	protected float knockbackTime = 0.4f;

	// returns isGrounded from PlayerGroundCheck component
	public bool isGrounded {
		get {
			return groundCheck.isGrounded;
		}
	}

	public bool isMoving {
		get {
			return playerMovement.isMoving;
		}
	}

	// returns energy saturation from PlayerEnergyCollector
	public bool isSaturated {
		get {
			return playerEnergy.isSaturated;
		}
	}

	public bool inControl {
		protected set;
		get;
	}

	public float Knockback {
		get {
			return this.knockback;
		}
	}

	public float KnockbackTime {
		get {
			return this.knockbackTime;
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

	public Key queueDisappearingKey {
		set;
		get;
	}

	private PlayerMovement playerMovement;
	private PlayerGroundCheck groundCheck;
	private PlayerEnergyCollector playerEnergy;

	private Animator anim;

	private float invincibleTime = 0f;

	// Use this for initialization
	protected override void Awake () {

		base.Awake ();

		anim = GetComponent<Animator> ();
		groundCheck = GetComponent<PlayerGroundCheck> ();
		playerEnergy = GetComponent<PlayerEnergyCollector> ();
		playerMovement = GetComponent<PlayerMovement> ();
		rb = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		useMovement = true;
	}

	protected virtual void Update() {
		invincibleTime -= Time.deltaTime;

		if (invincibleTime <= 0f) {
			RegainMortality ();
			invincibleTime = 0f;
		}
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
		rb.velocity = Vector2.zero;
	}

	public void LoseControl(float t) {
		PauseMovement ();
		StartCoroutine (RegainMovementInSeconds (t));
	}

	public void LoseControl() {
		PauseMovement ();
	}

	public void KeyVanish() {
		queueDisappearingKey.SetVisible (false);
	}

	// calls SetBool in the Animator component
	public void SetAnimation(string animationName, bool val) {
		anim.SetBool (animationName, val);
	}

	// calls SetTrigger in the Animator component
	public void TriggerAnimation(string animationName) {
		anim.SetTrigger (animationName);
	}

	public void ResetTrigger(string animationName) {
		anim.ResetTrigger (animationName);
	}

	public void SetInvincible() {
		invincibleTime = invincibilityDuration;
		gameObject.layer = LayerMask.NameToLayer ("Invincible");
	}

	public void SetInvincible(bool forever) {
		gameObject.layer = LayerMask.NameToLayer ("Invincible");
	}

	public void SetInvincible(float flashInterval) {
		invincibleTime = invincibilityDuration;
		gameObject.layer = LayerMask.NameToLayer ("Invincible");
		StartCoroutine (Flash (flashInterval));
	}

	public void RegainMortality() {
		gameObject.layer = LayerMask.NameToLayer ("Player");
	}

	public void TransitionScene() {
		SceneManager.LoadSceneAsync (LevelGate.Instance.nextLevel, LoadSceneMode.Single);
	}

	protected IEnumerator RegainMovementInSeconds(float t) {
		yield return new WaitForSeconds (t);
		ResumeMovement ();
	}

	protected IEnumerator Flash(float time) {
		yield return new WaitForSeconds (time);

		if (invincibleTime > 0f) {
			spriteRenderer.enabled = !spriteRenderer.enabled;
			StartCoroutine (Flash (time));
		} else {
			spriteRenderer.enabled = true;
		}
	}
}
