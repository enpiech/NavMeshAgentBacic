using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	private Player _player;

	// Use this for initialization
	void Start () {
		_player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.isGameOver)
			return;

		if (Input.GetKey(KeyCode.W))
		{
			_player.MoveForward();
		}
		else if (Input.GetKey(KeyCode.S))
		{
			_player.MoveBack();
		}

		if (Input.GetKey(KeyCode.A))
		{
			_player.RotateLeft();
		}
		else if (Input.GetKey(KeyCode.D))
		{
			_player.RotateRight();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_player.Jump();
		}

		if (Input.GetKey(KeyCode.F))
		{
			_player.Shot();
		}
	}
}
