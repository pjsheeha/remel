﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Utilities;
using Remel.Player;

namespace Remel.Managers {

	public class GameManager : PersistentSingleton<GameManager> {

		[SerializeField]
		public GameObject projectilePrefab;

		PlayerMovement playerMovement;

		// Use this for initialization
		void Start () {
			playerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		void OnGUI() {
			if (GUI.Button (new Rect (10, 10, 150, 30), "Reset")) {
				if (playerMovement != null) {
					playerMovement.ResetPosition ();
				}
			}
		}
	}
}