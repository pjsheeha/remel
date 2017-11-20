using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

	[SerializeField]
	CanvasGroup menuPanel;

	protected void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) && SceneManager.GetActiveScene().name != "title") {
			menuPanel.gameObject.SetActive (!menuPanel.gameObject.activeSelf);
		}
	}

	public void BackToMenu() {
		SceneManager.LoadSceneAsync ("title");
	}
}
