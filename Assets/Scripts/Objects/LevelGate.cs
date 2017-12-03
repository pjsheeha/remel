using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : Singleton<LevelGate> {

	public string nextLevel;

	protected Animator anim;
	protected bool unlocked;

	protected void Awake() {
		base.Awake ();

		anim = GetComponent<Animator> ();
		unlocked = false;
	}

	protected void OnTriggerEnter2D (Collider2D c) {
		if (c.GetComponent<PlayerManager> () && unlocked) {
			PlayerManager pm = c.GetComponent<PlayerManager> ();


			Vector2 pmAdjustedPosition = pm.rb.position;
			pmAdjustedPosition.x = transform.position.x;
			pm.rb.position = pmAdjustedPosition;
			pm.PauseMovement ();
			pm.SetInvincible ();
			SoundManager.instance.PlaySound ("tri");

			print ("Change Level");

			// SceneManager.LoadSceneAsync (nextLevel, LoadSceneMode.Single);

			pm.TriggerAnimation ("exit");
			anim.SetTrigger ("open");

		}
	}

	public void Unlock() {
		unlocked = true;
		anim.SetBool ("unlocked", unlocked);
	}

	public void Lock() {
		unlocked = false;
		anim.SetBool ("unlocked", unlocked);
	}
}
