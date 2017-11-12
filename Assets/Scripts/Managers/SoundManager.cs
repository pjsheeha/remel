using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager> {

	public static SoundManager instance = null;

	// Remel Audio
	public AudioClip Walk1Audio;
	private AudioSource walk1Audio;

	public AudioClip Walk2Audio;
	private AudioSource walk2Audio;

	public AudioClip CrystalCollectAudio;
	private AudioSource collectAudio;

	public AudioClip DeathAudio;
	private AudioSource deathAudio;

	public AudioClip JumpAudio;
	private AudioSource jumpAudio;

	public AudioClip ResetAudio;
	private AudioSource resetAudio;



	private Dictionary<string, AudioSource> sounds;

	void Awake () {

		base.Awake ();

		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

		sounds = new Dictionary<string, AudioSource> ();

		// Remel Audio
		walk1Audio = gameObject.AddComponent<AudioSource> ();
		walk1Audio.clip = Walk1Audio;
		sounds ["footstep-1"] = walk1Audio;

		walk2Audio = gameObject.AddComponent<AudioSource> ();
		walk2Audio.clip = Walk2Audio;
		sounds ["footstep-2"] = walk2Audio;

		deathAudio = gameObject.AddComponent<AudioSource> ();
		deathAudio.clip = DeathAudio;
		sounds ["Death Sound"] = deathAudio;

		jumpAudio = gameObject.AddComponent<AudioSource> ();
		jumpAudio.clip = JumpAudio;
		sounds ["jump"] = jumpAudio;

		collectAudio = gameObject.AddComponent<AudioSource> ();
		collectAudio.clip = CrystalCollectAudio;
		sounds ["Energy Collect Sound"] = collectAudio;

		resetAudio = gameObject.AddComponent<AudioSource> ();
		resetAudio.clip = ResetAudio;
		sounds ["reset"] = resetAudio;
	}


	public void PlaySound(string soundName) {
		AudioSource temp;
		if (sounds.TryGetValue (soundName, out temp)) {
			temp.Play ();
		}
	}

	public void StopSound(string soundName) {
		AudioSource temp;
		if (sounds.TryGetValue (soundName, out temp)) {
			temp.Stop ();
		}
	}
}
