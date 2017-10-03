using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;

namespace Remel.Player {

	[RequireComponent(typeof(PlayerManager))]

	/**
	 * PlayerEnergyCollector class stores how many neg-energy particles the
	 * player collects, sets energy capacity, and detects energy saturation
	 * 
	 * Also changes player color proportional to saturation (subject to change)
	 */
	public class PlayerEnergyCollector : MonoBehaviour {

		[SerializeField]
		protected Color saturationColor;
		[SerializeField]
		protected int energyCapacity = 10;

		public bool isSaturated {
			get {
				return playerEnergy >= energyCapacity;
			}
		}

		public Color SaturationColor {
			get {
				return this.saturationColor;
			}
		}

		public float Saturation {
			get {
				return (float)playerEnergy / (float)energyCapacity;
			}
		}

		public int Energy {
			get {
				return playerEnergy;
			}
		}

		protected int playerEnergy = 0;

		public void LoseEnergy () {
			playerEnergy--;
		}

		// boolean that gets used in PlayerManager component
		public bool IncrementEnergy() {
			if (playerEnergy < energyCapacity) {
				playerEnergy++;
				return true;
			}

			return false;
		}
	}
}