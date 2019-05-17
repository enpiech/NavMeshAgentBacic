using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	bool _isRunning = false;

	IEnumerator DelayForFire()
	{
		CanFire = false;

		CreateBullet();

		SoundManager.instance.PlayFireSound();

		yield return new WaitForSecondsRealtime(1f);
		CanFire = true;
	}

	protected override void StartCharacter()
	{
		UIManager.instance.UpdateHealthBar(HealthPercent);
	}

	public override void Shot()
	{
		base.Shot();

		if (CanFire)
		{
			StartCoroutine(DelayForFire());
		}
	}

	public override bool Hit(int damage)
	{
		int health = this.DecreaseHealth(damage);
		UIManager.instance.UpdateHealthBar(HealthPercent);

		if (health <= 0 && !IsDead)
		{
			Die();
			return true;
		}

		return false;
	}

	public override void Die()
	{
		IsDead = true;
		DataManager.instance.Coin = this._coin;
		UIManager.instance.ShowDialogDead();
		GameManager.isGameOver = true;
	}

	private int _coin = 0;

	public void IncreaseScore(int amount = 1)
	{
		_coin += amount;
		UIManager.instance.UpdateScore(_coin);
	}

	void OnCollisionEnter(Collision collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == GameManager.INVISIBLE_WALL_TAG)
		{
			Die();
			return;
		}
	}
}
