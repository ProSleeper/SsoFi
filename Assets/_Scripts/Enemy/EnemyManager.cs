using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TAG_NAME
{
	Untagged,
	Player,
	PlayerBullet,
	Enemy,
	EnemyBullet,
	Item
}

public class EnemyManager : MonoBehaviour
{
    private static EnemyManager _instance = null;

    public static EnemyManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("EnemyManager == null");
            return _instance;
        }
    }

	void Awake()
    {
        _instance = this;
    }

	List<GameObject> EnemyList = new List<GameObject>();

	public float spawnTime;

	int DeathCount;
	public int Count
	{
		get
		{
			return DeathCount;
		}
	}

	GameObject EnemyInfo;
	GameObject SpawnEnemy;
	Vector3 SpawnPos;

	void Start()
    {
		EnemyInfo = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;
		DeathCount = 0;
		StartSpawn();
	}

	private void Update()
	{
		//Debug.Log(EnemyList.Count);
	}

	public void StartSpawn()
	{
		StartCoroutine("EnemySpawn");
	}

	void Spawn()
	{
		SpawnPos = new Vector3(Random.Range(10, Screen.width), Random.Range(10, Screen.height), 0);
		SpawnPos = Camera.main.ScreenToWorldPoint(SpawnPos);

		SpawnEnemy = Instantiate(EnemyInfo, SpawnPos, Quaternion.identity) as GameObject;
		SpawnEnemy.transform.position = new Vector3(SpawnEnemy.transform.position.x, SpawnEnemy.transform.position.y, 0);
		SpawnEnemy.transform.parent = this.transform;
		EnemyList.Add(SpawnEnemy);
	}

    IEnumerator EnemySpawn()
    {
		while (true)
        {
            yield return new WaitForSeconds(spawnTime);
			Spawn();
		}
    }

	public void StopSpawn()
	{
		StopCoroutine("EnemySpawn");
	}

	public void OnDeath()
	{
		DeathCount++;
		ScoreManager.Instance.AddScore();
		//Debug.Log(DeathCount);
	}

	public void RemoveAllEnemy()
	{
		StopSpawn();
		GameObject[] temp = new GameObject[this.transform.childCount];

		//하위 자식 전부 삭제 코드 1
		//for (int i = 0; i < this.transform.childCount; i++)
		//{
		//	temp[i] = this.transform.GetChild(i).gameObject;
		//}
		//for (int i = 0; i < this.transform.childCount; i++)
		//{
		//	Destroy(temp[i]);
		//}

		//하위 자식 전부 삭제 코드 2
		//for (int i = 0; i < this.transform.childCount; i++)
		//{
		//	Destroy(this.transform.GetChild(0).gameObject);
		//}

		//하위 자식 전부 삭제 코드 3
		foreach (GameObject item in EnemyList)
		{
			Destroy(item);
		}
		EnemyList.Clear();
	}
}
