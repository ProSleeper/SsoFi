using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
		TagCheck.SetColl();
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
	}

	// Update is called once per frame
	void Update()
	{
		CurTime += Time.deltaTime;
		if (CurTime > 1.0f)
		{
			FPS.text = "FPS : " + FPSCount.ToString();
			FPSCount = 0;
			CurTime = 0;
			
		}
		else
		{
			FPSCount++;
		}
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

	void StageGameOver()
	{
		//CurPhase = STAGE_PHASE.GamaOver;
	}
}
