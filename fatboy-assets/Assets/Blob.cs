using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using Remel.Player;

public class Blob : MonoBehaviour {

	[SerializeField]
	protected float sizeChangeSpeed = 1f;
	[SerializeField]
	protected float maxSize = 2.5f;
	[SerializeField]
	protected float dist_ground= 0f;
	[SerializeField]
	protected Vector2 sizeLimits = new Vector2(0.1f, 4f);

	public bool isInAir = false;

	private SpriteRenderer sr;

	private float h_Input;

	private float transamt = 1;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		dist_ground = transform.localScale.y / 2;
	}
	
	// Update is called once per frame
	void Update () {
		h_Input = Input.GetAxis ("Horizontal");

		ChangeSizeOnMovement (h_Input);
	}

	protected void ChangeSizeOnMovement(float horizontal) {
		if (!isInAir) {
			dist_ground = transform.localScale.y / 2;
			transform.localPosition = new Vector3(transform.localPosition.x, dist_ground, transform.localPosition.z);
			transform.localScale += Vector3.one * horizontal * sizeChangeSpeed * Time.deltaTime;

			if (transform.localScale [0] < 1)
				transform.localScale = Vector3.one;

			else if (transform.localScale [0] > 2.5)
				transform.localScale = Vector3.one * maxSize;
		}

	}
}
