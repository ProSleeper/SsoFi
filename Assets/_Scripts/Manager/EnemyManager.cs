using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	const int MaxDeathCount = 500;

	List<GameObject> EnemyList = new List<GameObject>();

	public float spawnTime;

	int DeathCount;

	GameObject EnemyInfo;
	GameObject SpawnEnemy;
	GameObject BossInfo;
	GameObject BossEnemy;
	
	Vector3 SpawnPos;

	UILabel DeadCountText;

	void Start()
    {
		EnemyInfo = Resources.Load("Prefabs/Enemy/Enemy") as GameObject;
		BossInfo = Resources.Load("Prefabs/Enemy/BossEnemy") as GameObject;
		DeathCount = 0;
		DeadCountText = GameObject.Find("DeadCount").GetComponentInChildren<UILabel>();
		DeadCountText.text = DeathCount.ToString() + " / " + MaxDeathCount.ToString();

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
		SpawnPos.z = 0;

		if (Mathf.Abs((OnLoad.Player.transform.position - SpawnPos).magnitude) < 6.0f) 
		{
			return;
		}

		SpawnEnemy = Instantiate(EnemyInfo, SpawnPos, Quaternion.identity) as GameObject;
		SpawnEnemy.GetComponent<Enemy>().CHASESPEED = 2;
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

	public void OnDeath(GameObject RemoveEnemy)
	{
		DeathCount++;
		ScoreManager.Instance.AddScore();
		DeadCountText.text = DeathCount.ToString() + " / " + MaxDeathCount.ToString();

		EnemyList.Remove(RemoveEnemy);
		//Debug.Log(DeathCount);
		if (DeathCount >= MaxDeathCount)
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
		foreach (GameObject enemy in EnemyList)
		{
			enemy.GetComponent<Enemy>().SpawnParticle();
			Destroy(enemy);
		}
		EnemyList.Clear();
	}
}
