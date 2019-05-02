using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Transform[] _spawnerPositions;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform _target;


    IEnumerator spawn()
    {
        yield return new WaitForSeconds(1f);

        SpawnEnemy();

        StartCoroutine("spawn");
    }

    // Use this for initialization
    void Start () {
        StartCoroutine("spawn");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Transform position = _spawnerPositions[Random.Range(0, _spawnerPositions.Length)];
        GameObject enemy = Instantiate(_enemyPrefab, position.position, Quaternion.identity);

        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.SetTarget(_target);
        }
    }
}
