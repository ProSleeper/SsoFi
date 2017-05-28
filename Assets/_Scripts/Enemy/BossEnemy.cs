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
	const float CHANGETIME = 5f;
	const float MOVETIME = 2f;
	const int MOVEPOINT = 3;
	const int MAXHP = 100;


	float ChangeTransTime;
	float CurHp;
	
	Vector3 StartPosition;
	Vector3 EndPosition;

	Transform[] Point = new Transform[MOVEPOINT];
	BossBulletCreator BulletControler;
	
	BOSS_STATE CurState;
		
	void Start()
	{
		OnLoad.Player = GameObject.Find("Player");
		OnLoad.Item = Resources.Load("Prefabs/Item") as GameObject;
		BulletControler = this.transform.GetChild(0).GetComponent<BossBulletCreator>();
		BulletControler.gameObject.SetActive(false);
		PlayerDir = Vector3.zero;
		EndPosition = Vector3.zero;
		StartPosition = Vector3.zero;
		ChangeTransTime = 0;
		InvokeRepeating("RandomTrans", CHANGETIME, CHANGETIME);
		int sonCount = 0;
		for (int i = 0; i < this.transform.parent.childCount; i++)
		{
			if (this.transform.parent.GetChild(i).name.Contains("Point"))
			{
				Point[sonCount++] = this.transform.parent.GetChild(i);
			}
			
		}
		this.transform.position = Point[0].position;
		CurState = BOSS_STATE.BS_IDLE;
		CurHp = MAXHP;
		
		this.gameObject.tag = TAG_NAME.Enemy.ToString();
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
		if (CurState == BOSS_STATE.BS_MOVE)
		{
			StopAttack();
			ChangeTransTime += Time.deltaTime;
			this.transform.position =  Vector3.Lerp(StartPosition, EndPosition, ChangeTransTime / MOVETIME);
			if (ChangeTransTime > MOVETIME)
			{
				ChangeTransTime = 0;
				CurState = BOSS_STATE.BS_ATTACK;
				AttackPlayer();
			}
		}
	}

	void RandomTrans()
	{
		StartPosition = this.transform.position;
		EndPosition = Point[Random.Range(0, MOVEPOINT)].position;
		EndPosition.z = 0;
		CurState = BOSS_STATE.BS_MOVE;
	}

	void AttackPlayer()
	{
		BulletControler.gameObject.SetActive(true);
	}

	void StopAttack()
	{
		BulletControler.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			CurHp -= 1;
			Debug.Log("으악");
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (1.0f / MAXHP) * CurHp);
			if (CurHp <= 30)
			{
				Destroy(this.transform.gameObject);
			}
			//Destroy(this.transform.gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			CurHp -= 1;
			Debug.Log("으악");
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (1.0f / MAXHP) * CurHp);
			if (CurHp <= 30)
			{
				Destroy(this.transform.gameObject);
			}
			//Destroy(this.transform.gameObject);
		}
	}
}
