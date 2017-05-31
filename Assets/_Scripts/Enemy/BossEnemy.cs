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
	const int MAXHP = 700;

	float ChangeTransTime;
	
	Vector3 StartPosition;
	Vector3 EndPosition;

	Transform[] Point = new Transform[MOVEPOINT];
	BossBulletCreator BulletController;
	
	BOSS_STATE CurState;
		
	void Start()
	{
		BulletController = this.transform.GetChild(0).GetComponent<BossBulletCreator>();
		BulletController.gameObject.SetActive(false);
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
		Health = MAXHP;
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
		BulletController.gameObject.SetActive(true);
	}

	void StopAttack()
	{
		BulletController.gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			//수정해야할코드
			if (collision.tag.Equals("Player"))
			{
				return;
			}
			CalculateHealth(collision.GetComponent<DefaultBullet>().BulletPower());
		}
	}

	//private void OnTriggerStay2D(Collider2D collision)
	//{
	//	if (OnLoad.GetColl(this.tag, collision.tag))
	//	{
	//		if (collision.tag.Equals("Player"))
	//		{
	//			return;
	//		}
	//		//수정해야할코드
	//		CalculateHealth(collision.GetComponent<DefaultBullet>().BULLETDAMAGE);
	//	}
	//}

	public override void CollisionProcess()
	{
		Destroy(this.transform.gameObject);
	}

	public override void CalculateHealth(float damage)
	{
		Health -= damage;
		Debug.Log("으악");
		this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, (1.0f / MAXHP) * (Health + 350));
		if (Health <= 0)
		{
			CollisionProcess();
		}
	}
}
