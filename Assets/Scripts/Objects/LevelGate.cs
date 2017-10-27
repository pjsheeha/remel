using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Remel.Player;

using Remel.Objects;

namespace Remel.Objects {

	public class LevelGate : MonoBehaviour {

		public string nextLevel;

		protected void OnTriggerEnter2D (Collider2D c) {
			if (c.GetComponent<PlayerManager> ()) {
				PlayerManager pm = c.GetComponent<PlayerManager> ();


					pm.PauseMovement ();
					print ("Change Level");

				SceneManager.LoadSceneAsync (nextLevel, LoadSceneMode.Single);

			}
		}
	}

}