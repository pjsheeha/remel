using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Restart() {
		GameManager.Instance.GoToScene (GameManager.TITLE_SCENE_NAME);
	}
}
