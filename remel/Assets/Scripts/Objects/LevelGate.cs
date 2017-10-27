using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Remel.Player;
using Remel.Managers;
using Remel.Objects;

namespace Remel.Objects {

	public class LevelGate : MonoBehaviour {

		public string nextLevel;

		protected void OnTriggerEnter2D (Collider2D c) {
			if (c.GetComponent<PlayerManager> ()) {
				PlayerManager pm = c.GetComponent<PlayerManager> ();

				if (LevelManager.Instance.CollectedAllEnergy) {
					pm.PauseMovement ();
					print ("Change Level");

					SceneManager.LoadScene (nextLevel);
				}
			}
		}
	}

}