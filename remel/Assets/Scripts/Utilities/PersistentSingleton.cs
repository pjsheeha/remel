using UnityEngine;
using System.Collections;

namespace Remel.Utilities {

	// PersistentSingleton class
	// persistent singleton objects will not be destroyed after scene changes
	public class PersistentSingleton<T> : Singleton<T> where T : Singleton<T> {

		protected override void Awake() {
			base.Awake();
			DontDestroyOnLoad(gameObject);
		}

	}
}
