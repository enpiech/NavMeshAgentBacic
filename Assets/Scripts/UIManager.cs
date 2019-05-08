using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField]
	private GameObject _uiDead;

	[SerializeField]
	private Image _imgProcessHealthBar;

	[SerializeField]
	private Text _txtScore;

	public static UIManager instance;

	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(instance);
		}

		instance = this;
	}

	void Start () {
		_uiDead.SetActive(false);

		UpdateScore(DataManager.instance.Coin);
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
		_imgProcessHealthBar.fillAmount = percent;
	}

	public void UpdateScore(int coin)
	{
		_txtScore.text = FormatCoinToString(coin);
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
}
