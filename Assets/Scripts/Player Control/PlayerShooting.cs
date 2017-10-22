using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Potentially temporary component. Didn't bother putting it in a namespace.
 */
public class PlayerShooting : MonoBehaviour {

	[SerializeField]
	protected Transform hand;

	private SpriteRenderer sr;

	private bool animationLocked;
	private float h_Input;

	// Use this for initialization
	void Start () {
		animationLocked = false;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (animationLocked) {
			return;
		}

		h_Input = Input.GetAxis ("Horizontal");

		sr.flipX = h_Input != 0f ? (h_Input > 0f ? false : true) : sr.flipX;

		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
			animationLocked = true;

			GetComponent<PlayerManager> ().TriggerAnimation ("fire");
		}
	}

	public void ShootProjectile(float angle) {
		float angleOffset = sr.flipX ? 0f : 180f;
		float angleMultiplier = sr.flipX ? -1f : 1f;

		Vector3 firingPosition = new Vector3 (
			hand.position.x * (sr.flipX ? -1f : 1f),
			hand.position.y,
			0f
		);

		Instantiate<GameObject> (
			GameManager.Instance.projectilePrefab,
			firingPosition,
			Quaternion.Euler(new Vector3(0f, 0f, angleMultiplier * angle + angleOffset))
		);
	}

	public void FreeAnimation() {
		this.animationLocked = false;
	}
}
