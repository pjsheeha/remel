using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Persistent Singleton game manager object. Will keep track of game data
 * and can be called using GameManager.Instance
 */
public class GameManager : PersistentSingleton<GameManager> {

	public static string TITLE_SCENE_NAME = "title";
	public static string FIRST_LEVEL_SCENE_NAME = "rlevel0";

	[SerializeField]
	public GameObject projectilePrefab;
	[SerializeField]
	public GameObject negativeEnergyPrefab;
	[SerializeField]
	public GameObject positiveEnergyPrefab;

	PlayerMovement playerMovement;

	protected void OnEnable() {
		print("GameManager Enabled");
	}

	// Use this for initialization
	void Start () {
		 playerMovement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button6)) {

			PlayerManager.Instance.GetComponent<PlayerMovement> ().ResetPosition ();
			PlayerManager.Instance.ResumeMovement ();
			SoundManager.instance.PlaySound ("reset");
		}
	}




	public void GoToScene(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void ExitGame() {
		Application.Quit ();
	}
}
