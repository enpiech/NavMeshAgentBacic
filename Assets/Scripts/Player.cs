using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {
	IEnumerator DelayForFire()
	{
		CanFire = false;

		CreateBullet();

		yield return new WaitForSecondsRealtime(1f);
		CanFire = true;
	}

	public override void Shot()
	{
		base.Shot();

		if (CanFire)
		{
			StartCoroutine(DelayForFire());
		}
	}

	public override void Hit(int damage)
	{
		int health = this.DecreaseHealth(damage);
		if (_health <= 0 && !IsDead)
		{
			Die();
		}

		UIManager.instance.UpdateHealthBar(HealthPercent);
	}

	public override void Die()
	{
		IsDead = true;
		UIManager.instance.ShowDialogDead();
	}
}
