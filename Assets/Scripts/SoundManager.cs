using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	[SerializeField]
	private AudioSource _audio;
	[SerializeField]
	private AudioClip[] _clips;

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		instance = this;

		// Never destroy it
		DontDestroyOnLoad(this.gameObject);
	}

	public void PlayFireSound()
	{
		_audio.PlayOneShot(_clips[0]);
	}
}
