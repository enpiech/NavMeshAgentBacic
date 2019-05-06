using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

	public static DataManager instance;

	private const string KEY_COIN = "kasdlakjl_f098q)@()@!*fasdfas";

	private int _coin = 0;

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
		_coin = PlayerPrefs.GetInt(KEY_COIN, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int Coin
	{
		set
		{
			this._coin = value;
			PlayerPrefs.SetInt(KEY_COIN, this._coin);
		}

		get
		{
			return this._coin;
		}
	}
}
