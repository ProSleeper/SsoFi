using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum STAGE_PHASE
{
	Ready,
	Common,
	Boss,
	GamaOver
}

public enum TAG_NAME
{
	Untagged,
	Player,
	PlayerBullet,
	Enemy,
	EnemyBullet,
	Item,
	Max
}

//Enemy에서 사용할 것들.. 한번씩만 로드하면 되는데 Enemy 코드에 넣으면 생성 될때마다 하기에 이렇게 둠..
//나중엔 이런종류를 한군데다가 모아서 한번에 로드시키는게 좋을듯
public static class OnLoad
{
	public static GameObject EnemyParticle;
	public static GameObject BulletParticle;
	public static GameObject ThinBulletParticle;
	public static GameObject ThinSubBullet;
	public static GameObject Player;
	public static GameObject Item;

	static bool[,] collTag;
	static Dictionary<string, TAG_NAME> DicTagName = new Dictionary<string, TAG_NAME>();

	public static void OnEnemyDataLoad()
	{
		Player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item/Item") as GameObject;
		ThinSubBullet = Resources.Load("Prefabs/Bullet/Entity/SubEntity/ExplosionScope") as GameObject;

		EnemyParticle = Resources.Load("Prefabs/Enemy/EnemyParticleTriangle") as GameObject;
		BulletParticle = Resources.Load("Prefabs/Bullet/BulletParticle") as GameObject;
		ThinBulletParticle = Resources.Load("Prefabs/Bullet/ThinBulletParticle") as GameObject;
	}

	public static void SetColl()
	{
		collTag = new bool[(int)TAG_NAME.Max, (int)TAG_NAME.Max];

		collTag[(int)TAG_NAME.Player, (int)TAG_NAME.Enemy] = true;
		collTag[(int)TAG_NAME.Enemy, (int)TAG_NAME.Player] = true;

		collTag[(int)TAG_NAME.Player, (int)TAG_NAME.EnemyBullet] = true;
		collTag[(int)TAG_NAME.EnemyBullet, (int)TAG_NAME.Player] = true;
		
		collTag[(int)TAG_NAME.Item, (int)TAG_NAME.Player] = true;

		collTag[(int)TAG_NAME.PlayerBullet, (int)TAG_NAME.Enemy] = true;
		collTag[(int)TAG_NAME.Enemy, (int)TAG_NAME.PlayerBullet] = true;

		DicTagName.Clear();

		for (int i = 0; i < (int)TAG_NAME.Max; i++)
		{
			DicTagName.Add(((TAG_NAME)i).ToString(), (TAG_NAME)i);
		}
	}

	public static bool GetColl(string thisObject, string collObject)
	{
		TAG_NAME thisNum;
		TAG_NAME collNum;
		DicTagName.TryGetValue(thisObject, out thisNum);
		DicTagName.TryGetValue(collObject, out collNum);

		return collTag[(int)thisNum, (int)collNum];
	
	}
}

public class GameManager : MonoBehaviour
{
	private static GameManager _instance = null;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("cSingleton == null");
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
		OnLoad.SetColl();
	}

	Text FPS;
	float CurTime = 0;
	int FPSCount = 0;
	STAGE_PHASE CurPhase;
	EnemyManager em;

	void Start()
	{
		CurPhase = STAGE_PHASE.Ready;
		FPS = GameObject.Find("FPS").GetComponent<Text>();
		em = this.GetComponent<EnemyManager>();
		Invoke("CommonStage", 3);
		CurPhase = STAGE_PHASE.Ready;
	}

	// Update is called once per frame
	void Update()
	{
		//CurTime += Time.deltaTime;
		//if (CurTime > 1.0f)
		//{
		//	FPS.text = "FPS : " + FPSCount.ToString();
		//	FPSCount = 0;
		//	CurTime = 0;
			
		//}
		//else
		//{
		//	FPSCount++;
		//}
	}

	void CommonStage()
	{
		CurPhase = STAGE_PHASE.Common;
		em.StartSpawn();
	}

	void BossStage()
	{
		//CurPhase = STAGE_PHASE.Boss;
		//em.StopSpawn();
		//em.BossSpawn();
	}

	public void StageGameOver()
	{
		CurPhase = STAGE_PHASE.GamaOver;
		SceneManager.LoadScene(2);
	}
}
