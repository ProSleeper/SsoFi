using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum STAGE_PHASE
{
	Ready,
	PlayerGame,
	GameOver
}

//시작은 코루틴이나 인보크 사용해서 시작!
public class GameManager : MonoBehaviour
{
	private static GameManager _instance = null;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("EnemyManager == null");
			return _instance;
		}
	}

	STAGE_PHASE CurPhase;

	void Awake()
	{
		_instance = this;
		CollTag.SetColl();
		LoadData.OnEnemyDataLoad();
	}

	void Start()
	{
		Invoke("PlayGame", 3);
		CurPhase = STAGE_PHASE.Ready;
	}

	void Update()
	{
		if (CurPhase == STAGE_PHASE.GameOver)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void Ready()
	{

	}

	public void PlayGame()
	{
		CurPhase = STAGE_PHASE.PlayerGame;
		EnemyManager.Instance.StartSpawn();
		ScoreManager.Instance.SetPrevTime();
	}

	public void GameClear()
	{
		CurPhase = STAGE_PHASE.GameOver;
		ResultManager.Instance.ClearResult();
	}

	public void GameOver()
	{
		CurPhase = STAGE_PHASE.GameOver;
		ResultManager.Instance.OverResult();
	}
}


