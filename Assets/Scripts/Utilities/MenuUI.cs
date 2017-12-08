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
	[SerializeField]
	GameObject titlePanel;

	private Animator anim;
	private bool playing = false;
	void Awake () {
		anim = titlePanel.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckMouseClick();
		CheckSkipScene ();
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

	private void CheckMouseClick() {
		if (Input.anyKeyDown && playing == false) {
			anim.SetTrigger ("transition");
			playing = true;

				SoundManager.instance.PlaySound ("open");

		}
	}

	private void CheckSkipScene() {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("transition") && Input.GetKeyDown (KeyCode.Escape)) {
			GameManager.Instance.GoToScene (GameManager.FIRST_LEVEL_SCENE_NAME);	
		}
	}
}
