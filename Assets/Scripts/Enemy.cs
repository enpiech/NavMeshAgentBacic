using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character {

    private NavMeshAgent _navMeshAgent;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _attackDistance = 3f;

	// Use this for initialization
	protected override void StartCharacter () {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = _target.position;
		//_navMeshAgent.stoppingDistance = _attackDistance;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.isGameOver)
		{
			_navMeshAgent.velocity = Vector3.zero;
			_navMeshAgent.isStopped = true;
			return;
		}

		Vector3 origin = transform.position;
		Vector3 destination = _target.position;

		_navMeshAgent.destination = _target.position;

		float distance = (origin - destination).magnitude;

		if (distance <= _attackDistance)
		{
			_navMeshAgent.velocity = Vector3.zero;

			Shot();
		}
	}

    public void SetTarget(Transform target)
    {
        this._target = target;
    }

	IEnumerator DelayForFire()
	{
		CanFire = false;

		CreateBullet();

		yield return new WaitForSecondsRealtime(2f);
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

	public override bool Hit(int damage)
	{
		int health = this.DecreaseHealth(damage);
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

		CreateEffectWithTimespan(3f);

		Destroy(this.gameObject);
	}
}
