using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BOSS_STATE
{
	BS_IDLE,
	BS_MOVE,
	BS_ATTACK,
	BS_MAX
}

public class BossEnemy : Enemy
{
	const float CHANGETIME = 5;
	const float MOVETIME = 2;
	const int ScreenSizeX = 1440;
	const int ScreenSizeY = 2560;

	float ChangeTransTime;
	bool IsMove;

	Vector3 StartPosition;
	Vector3 EndPosition;


	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item") as GameObject;
		playerDir = Vector3.zero;
		ChangeTransTime = 0;
		EndPosition = Vector3.zero;
		StartPosition = Vector3.zero;
		IsMove = false;
		InvokeRepeating("RandomTrans", 5, 5);
	}

	// Update is called once per frame
	void Update()
	{
		PlayerDirMove();
		PlayerDirRotation(playerDir, Vector3.up);

		chaseSpeed += Time.deltaTime * 0.1f;
	}

	override protected void PlayerDirMove()
	{
		if (IsMove)
		{
			ChangeTransTime += Time.deltaTime;
			this.transform.position =  Vector3.Lerp(StartPosition, EndPosition, ChangeTransTime / MOVETIME);
			if (ChangeTransTime > MOVETIME)
			{
				ChangeTransTime = 0;
				IsMove = false;
			}
		}
	}

	void RandomTrans()
	{
		Vector3 temp = new Vector3(Random.Range((1440 * 0.1f), (1440 * 0.9f)), Random.Range((2560 * 0.1f), (2560 * 0.9f)), 0);
		StartPosition = this.transform.position;
		EndPosition = Camera.main.ScreenToWorldPoint(temp);
		EndPosition.z = 0;
		IsMove = true;
		Debug.Log(EndPosition);
	}
}
