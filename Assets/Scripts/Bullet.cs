using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private float _speed = 100;

	[SerializeField] private Vector3 _direction;
	private Rigidbody _rigidbody;
	private Transform _transform;
	private Character _parent;

	// Use this for initialization
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
		_transform = transform;
		_direction = transform.forward;

		print(_parent);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 v = _direction * _speed * Time.deltaTime;
		v.y = _rigidbody.velocity.y;
		_rigidbody.velocity = v;

	}

	public void SetDirection(Vector3 direction)
	{
		_direction = direction;
	}

	void OnTriggerEnter(Collider collider)
	{
		string tag = collider.gameObject.tag;
		GameObject obj = collider.gameObject;
		print(obj);

		if (tag == Constant.TAG_ENEMY && _parent.IsPlayer)
		{
			Enemy e = obj.GetComponent<Enemy>();
			bool isDie = e.Hit(_parent.Damage);
			if (isDie)
			{
				Player p = _parent.GetComponent<Player>();
				p.IncreaseScore();
			}
			Destroy(gameObject);
		}
		else if (tag == Constant.TAG_PLAYER && _parent.IsEnemy)
		{
			Player p = obj.GetComponent<Player>();
			p.Hit(_parent.Damage);
			Destroy(gameObject);
		}
		else if (tag == Constant.TAG_WALL)
		{
			Destroy(gameObject);
		}
	}

	public void SetParent(Character parent)
	{
		_parent = parent;
	}
}
