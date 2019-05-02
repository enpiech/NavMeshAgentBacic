using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public enum CharacterType
	{
		Enemy,
		Player
	}

	[SerializeField] CharacterType _type;

	[SerializeField] float _speed = 0;
	[SerializeField] float _moveAngle;

	[SerializeField]int _damage;
	[SerializeField]protected int _health;
	[SerializeField] int _jumpForce;

	[SerializeField]
	protected GameObject _bullet;
	[SerializeField]
	protected Transform _origin;

	[SerializeField]
	protected GameObject _effect;

	private int _maxHealth;
	protected Transform _transform;
	private Rigidbody _rigidbody;

	private bool _canJump = true;
	private bool _canShot = true;
	private bool _isDead = false;

	IEnumerator DelayForJump()
	{
		_rigidbody.AddForce(Vector3.up * _jumpForce);

		_canJump = false;
		yield return new WaitForSecondsRealtime(1f);
		_canJump = true;
	}

	// Use this for initialization
	void Start () {
		_maxHealth = _health;
		_rigidbody = GetComponent<Rigidbody>();
		_transform = transform;

		StartCharacter();
	}

	protected virtual void StartCharacter()
	{

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void SetType(CharacterType value)
	{
		_type = value;
	}

	public void MoveForward()
	{
		Vector3 v = _transform.forward * _speed * Time.deltaTime;
		v.y = _rigidbody.velocity.y;
		_rigidbody.velocity = v;
	}

	public void MoveBack()
	{
		Vector3 v = -1 * _transform.forward * _speed * Time.deltaTime;
		v.y = _rigidbody.velocity.y;
		_rigidbody.velocity = v;
	}

	public void RotateLeft()
	{

		Vector3 r = _transform.rotation.eulerAngles;
		r.y -= Time.deltaTime * _moveAngle;
		_transform.rotation = Quaternion.Euler(r);
		//_transform.Rotate(new Vector3(0, 1, 0), -1 * _moveAngle * Time.deltaTime);
	}

	public void RotateRight()
	{
		Vector3 r = _transform.rotation.eulerAngles;
		r.y += Time.deltaTime * _moveAngle;
		_transform.rotation = Quaternion.Euler(r);
	}

	public virtual void Hit(int damage)
	{
	}

	public virtual void Shot()
	{
	}

	protected void CreateBullet()
	{
		GameObject obj = Instantiate(_bullet, _origin.position, _transform.rotation);
		Bullet bullet = obj.GetComponent<Bullet>();
		bullet.SetParent(this);
	}

	public virtual void Die()
	{
	}

	public void Jump()
	{
		if (_canJump)
		{
			StartCoroutine(DelayForJump());
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (_rigidbody == null)
		{
			return;
		}
		Vector3 v = _rigidbody.velocity;
		v.x = 0;
		v.z = 0;
		_rigidbody.velocity = v;
	}

	public void CreateEffectWithTimespan(float timespan)
	{
		GameObject obj = Instantiate(_effect, transform.position, Quaternion.identity);
		Destroy(obj, timespan);
	}

	public bool IsPlayer
	{
		get
		{
			return _type == CharacterType.Player;
		}
	}

	public bool IsEnemy
	{
		get
		{
			return _type == CharacterType.Enemy;
		}
	}

	public int Damage
	{
		get
		{
			return _damage;
		}

		set
		{
			_damage = value;
		}
	}

	public int DecreaseHealth(int damage)
	{
		_health -= damage;
		return _health;
	}

	public float HealthPercent
	{
		get
		{
			return _health / _maxHealth;
		}
	}

	public bool CanFire
	{
		get
		{
			return _canShot;
		}

		set
		{
			_canShot = value;
		}
	}

	public bool IsDead
	{
		get
		{
			return _isDead;
		}

		set
		{
			_isDead = value;
		}
	}
}
