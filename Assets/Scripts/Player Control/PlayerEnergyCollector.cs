using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Remel.Player;

namespace Remel.Player {

	[RequireComponent(typeof(PlayerManager))]

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

		public bool IncrementEnergy() {
			if (playerEnergy < energyCapacity) {
				playerEnergy++;
				return true;
			}

			return false;
		}
	}
}