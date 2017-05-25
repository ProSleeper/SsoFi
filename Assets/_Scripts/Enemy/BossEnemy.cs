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
	const int MOVEPOINT = 5;

	float ChangeTransTime;
	bool IsMove;

	Vector3 StartPosition;
	Vector3 EndPosition;

	Transform[] Point = new Transform[MOVEPOINT];

	// Use this for initialization
	void Start()
	{
		OnLoad.Player = GameObject.Find("Player");
		OnLoad.Item = Resources.Load("Prefabs/Item") as GameObject;
		PlayerDir = Vector3.zero;
		EndPosition = Vector3.zero;
		StartPosition = Vector3.zero;
		ChangeTransTime = 0;
		IsMove = false;
		InvokeRepeating("RandomTrans", 5, 5);
		for (int i = 0; i < MOVEPOINT; i++)
		{
			Point[i] = this.transform.parent.FindChild("Point" + (i + 1).ToString());
		}
		this.transform.position = Point[0].position;
	}

	// Update is called once per frame
	void Update()
	{
		PlayerDirMove();
		PlayerDirRotation(PlayerDir, Vector3.up);

		ChaseSpeed += Time.deltaTime * 0.1f;
	}

	protected override void PlayerDirMove()
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
		StartPosition = this.transform.position;
		EndPosition = Point[Random.Range(0, MOVEPOINT)].position;
		EndPosition.z = 0;
		IsMove = true;
	}
}
