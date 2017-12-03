using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSequence : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BeginGame() {
		GameManager.Instance.GoToScene (GameManager.FIRST_LEVEL_SCENE_NAME);
	}
}
