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

//Enemy에서 사용할 것들.. 한번씩만 로드하면 되는데 Enemy 코드에 넣으면 생성 될때마다 하기에 이렇게 둠..
//나중엔 이런종류를 한군데다가 모아서 한번에 로드시키는게 좋을듯
public static class OnLoad
{
	public static GameObject DeadPrefab;
	public static GameObject Player;
	public static GameObject Item;

	public static void OnEnemyDataLoad()
	{
		Player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item") as GameObject;
		DeadPrefab = Resources.Load("Prefabs/Enemy/EnemyParticleTriangle") as GameObject;
	}
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
		OnLoad.OnEnemyDataLoad();
	}

	const int MaxDeathCount = 100;

	List<GameObject> EnemyList = new List<GameObject>();

	public float spawnTime;

	int DeathCount;

	GameObject EnemyInfo;
	GameObject SpawnEnemy;
	GameObject BossInfo;
	GameObject BossEnemy;

	Vector3 SpawnPos;

	void Start()
    {
		EnemyInfo = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;
		BossInfo = Resources.Load("Prefabs/Enemy/BossEnemy") as GameObject;
		DeathCount = 0;
		//StartSpawn();
	}

	public void StartSpawn()
	{
		StartCoroutine("EnemySpawn");
	}

	public void BossSpawn()
	{
		BossEnemy = Instantiate(BossInfo);
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
		RemoveAllEnemy();
	}

	public void OnDeath()
	{
		DeathCount++;
		ScoreManager.Instance.AddScore();

		Debug.Log(DeathCount);
		if (DeathCount > MaxDeathCount)
		{
			StopSpawn();
			BossSpawn();
		}
	}

	public void RemoveAllEnemy()
	{


		//하위 자식 전부 삭제 코드 1
		//GameObject[] temp = new GameObject[this.transform.childCount];
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
