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

	public AudioClip JumpAudio2;
	private AudioSource jumpAudio2;

	public AudioClip JumpAudio3;
	private AudioSource jumpAudio3;
	public AudioClip ResetAudio;
	private AudioSource resetAudio;

	public AudioClip BreathAudio;
	private AudioSource breathAudio;

	public AudioClip SqueakAudio;
	private AudioSource squeakAudio;

	public AudioClip CelebAudio;
	private AudioSource celebAudio;

	public AudioClip TriAudio;
	private AudioSource triAudio;

	public AudioClip PopAudio;
	private AudioSource popAudio;



	public AudioClip OpenAudio;
	private AudioSource openAudio;

	public AudioClip EndAudio;
	private AudioSource endAudio;
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

		jumpAudio2 = gameObject.AddComponent<AudioSource> ();
		jumpAudio2.clip = JumpAudio2;
		sounds ["jump2"] = jumpAudio2;

		jumpAudio = gameObject.AddComponent<AudioSource> ();
		jumpAudio.clip = JumpAudio;
		sounds ["jump"] = jumpAudio;

		jumpAudio3 = gameObject.AddComponent<AudioSource> ();
		jumpAudio3.clip = JumpAudio3;
		sounds ["jump3"] = jumpAudio3;
		collectAudio = gameObject.AddComponent<AudioSource> ();
		collectAudio.clip = CrystalCollectAudio;
		sounds ["Energy Collect Sound"] = collectAudio;

		resetAudio = gameObject.AddComponent<AudioSource> ();
		resetAudio.clip = ResetAudio;
		sounds ["reset"] = resetAudio;

		breathAudio = gameObject.AddComponent<AudioSource> ();
		breathAudio.clip = BreathAudio;
		sounds ["breath"] = breathAudio;

		squeakAudio = gameObject.AddComponent<AudioSource> ();
		squeakAudio.clip = SqueakAudio;
		sounds ["squeak"] = squeakAudio;

		triAudio = gameObject.AddComponent<AudioSource> ();
		triAudio.clip = TriAudio;
		sounds ["tri"] = triAudio;
		celebAudio = gameObject.AddComponent<AudioSource> ();
		celebAudio.clip = CelebAudio;
		sounds ["celeb"] = celebAudio;
		popAudio = gameObject.AddComponent<AudioSource> ();
		popAudio.clip = PopAudio;
		sounds ["pop"] = popAudio;
		openAudio = gameObject.AddComponent<AudioSource> ();
		openAudio.clip = OpenAudio;
		sounds ["open"] = openAudio;
		endAudio = gameObject.AddComponent<AudioSource> ();
		endAudio.clip = EndAudio;
		sounds ["end"] = endAudio;
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
