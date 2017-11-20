using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

	[SerializeField]
	CanvasGroup mainMenuPanel;
	[SerializeField]
	CanvasGroup levelSelectPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowMainMenu() {
		HideMenus ();
		mainMenuPanel.gameObject.SetActive (true);
	}

	public void ShowLevelSelect() {
		HideMenus ();
		levelSelectPanel.gameObject.SetActive (true);
	}

	public void GoToScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	private void HideMenus() {
		CanvasGroup[] cgs = GameObject.FindObjectsOfType<CanvasGroup> ();

		foreach (CanvasGroup cg in cgs) {
			GameObject o = cg.gameObject;
			o.SetActive (false);
		}
	}
}
