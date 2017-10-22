using UnityEngine;
using System.Collections;

// Singleton class
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T> {
	private static T instance;

	public static T Instance {
		get {
			return instance;
		}

		protected set {
			instance = value;
		}
	}

	protected virtual void Awake() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = (T)this;
		}
	}

	protected virtual void OnDestroy() {
		if (instance == this) {
			instance = null;
		}
	}
}
