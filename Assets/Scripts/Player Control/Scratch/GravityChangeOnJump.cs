using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Remel.Player {

	public class GravityChangeOnJump : JumpReplacement {

		private BoxCollider2D coll;
		private Rigidbody2D rb;
		private SpriteRenderer sr;

		// Use this for initialization
		void Start () {
			coll = GetComponent<BoxCollider2D> ();
			rb = GetComponent<Rigidbody2D> ();
			sr = GetComponent<SpriteRenderer> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				coll.offset = -coll.offset;
				rb.gravityScale = -rb.gravityScale;
				sr.flipY = !sr.flipY;

				rb.position -= Vector2.up * coll.size.y * Mathf.Sign(rb.gravityScale);
			}
		}
	}
}