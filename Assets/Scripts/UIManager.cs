using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private GameObject _uiDead;

	public static UIManager instance;

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(instance);
		}

		instance = this;
	}

	// Use this for initialization
	void Start () {
		_uiDead.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowDialogDead()
	{
		_uiDead.SetActive(true);
	}

	public void UpdateHealthBar(float percent)
	{

	}
}
