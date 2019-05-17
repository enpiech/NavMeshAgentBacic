using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool isGameOver = false;
	public const string INVISIBLE_WALL_TAG = "Wall";

    [SerializeField]
    private Transform[] _spawnerPositions;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform _enemyTarget;

	[SerializeField]
	private uint _spawnDelayTime = 1;
	[SerializeField]
	private uint _maxEnemy = 1;

	private uint _countCurrentEnemy = 0;

    void Start () {
		isGameOver = false;

		StartCoroutine(spawn());
	}

	IEnumerator spawn()
	{
		if (!CanSpawnEnemy())
		{
			yield return null;
		}
		else
		{
			SpawnEnemy();
			_countCurrentEnemy++;

			yield return new WaitForSeconds(_spawnDelayTime);

			StartCoroutine(spawn());
		}	
	}

	bool CanSpawnEnemy()
	{
		if (GameManager.isGameOver)
			return false;

		if (_countCurrentEnemy >= _maxEnemy)
			return false;

		return true;
	}

	void SpawnEnemy()
    {
        Transform spawnPosition = _spawnerPositions[Random.Range(0, _spawnerPositions.Length)];
        GameObject enemy = Instantiate(_enemyPrefab, spawnPosition.position, Quaternion.identity);

        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.SetTarget(_enemyTarget);
        }
    }
}
