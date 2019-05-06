using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private GameObject _uiDead;

	[SerializeField]
	private Image _processHealthBar;

	[SerializeField]
	private Text _scoreText;

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

		UpdateScore(DataManager.instance.Coin);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Replay()
	{
		SceneManager.LoadScene(0);
	}

	public void ShowDialogDead()
	{
		_uiDead.SetActive(true);
	}

	public void UpdateHealthBar(float percent)
	{
		_processHealthBar.fillAmount = percent;
	}

	string FormatCoinToString(int coin)
	{
		string result = coin + "";

		if (result.Length < 2)
		{
			return "0000" + result;
		}
		else if (result.Length < 3)
		{
			return "000" + result;
		}
		else if (result.Length < 4)
		{
			return "00" + result;
		}
		else if (result.Length < 5)
		{
			return "0" + result;
		}
		else if (result.Length < 6)
		{
			return result;
		}

		return "";
	}

	public void UpdateScore(int coin)
	{
		_scoreText.text = FormatCoinToString(coin);
	}
}
