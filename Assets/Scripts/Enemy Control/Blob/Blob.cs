using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;

public class Blob : MonoBehaviour {

	[SerializeField]
	protected float sizeChangeSpeed = 1f;
	[SerializeField]
	protected Vector2 sizeLimits = new Vector2(0.1f, 4f);

	private SpriteRenderer sr;

	private float h_Input;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		h_Input = Input.GetAxis ("Horizontal");

		ChangeSizeOnMovement (h_Input);
	}

	protected void ChangeSizeOnMovement(float horizontal) {
		transform.localScale += Vector3.one * horizontal * sizeChangeSpeed * Time.deltaTime;
	}
}
