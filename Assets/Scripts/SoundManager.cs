using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

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

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SoundFirePlay()
	{
		_audio.PlayOneShot(_clips[0]);
	}
}
