using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExpel : MonoBehaviour {

	[SerializeField]
	protected float particleExpelSpeed = 10f;
	[SerializeField]
	protected Vector2 particleExpelAngles = new Vector2 (-15f, 15f);

	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		playerManager = GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow) && playerManager.Energy > 0) {
			// Initiate expel particle animation if energy > 0

			// playerManager.PauseMovement (); // pauses movement when expelling energy, can be commented out
			playerManager.TriggerAnimation ("spit");
		}
	}

	public void ExpelEnergy() {
		print ("PlayerExpel.ExpelEnergy");

		int energy = playerManager.Energy;

		for (int i = 0; i < energy; i++) {

			float angle = Random.value * (particleExpelAngles.y - particleExpelAngles.x) + particleExpelAngles.x;

			Rigidbody2D posEnergyRB = (
				Instantiate<GameObject> (
					GameManager.Instance.positiveEnergyPrefab,
					playerManager.mouth.position,
					Quaternion.Euler(new Vector3(0f, 0f, angle))
				)
			).GetComponent<Rigidbody2D> ();

			float direction = playerManager.spriteRenderer.flipX ? -1f : 1f;

			posEnergyRB.velocity = posEnergyRB.transform.right * direction * particleExpelSpeed;

			playerManager.LoseEnergy ();
		}

	}
}
