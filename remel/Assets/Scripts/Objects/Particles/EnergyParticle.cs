using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;

namespace Remel.Objects {
	public class EnergyParticle : MonoBehaviour {

		[SerializeField]
		protected Vector2 lifetimeRange = new Vector2 (0.35f, 0.75f);
		[SerializeField]
		protected Vector2 startSpeedRange = new Vector2 (0.2f, 0.4f);

		private ParticleSystem partSys;

		// Use this for initialization
		protected virtual void Start () {
			partSys = GetComponent<ParticleSystem> ();
			ParticleSystem.MainModule main = partSys.main;

			main.startLifetime = Random.value * (lifetimeRange.y - lifetimeRange.x) + lifetimeRange.x;
			main.startSpeedMultiplier = Random.value * (startSpeedRange.y - startSpeedRange.x) + startSpeedRange.x;
		}

	}
}