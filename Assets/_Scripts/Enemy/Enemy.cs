using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	const float SPAWN_PERCENT = 3.0f;
	const int MAXHP = 20;

	protected Vector3 PlayerDir;
	protected float Health;
	protected float ChaseSpeed;

	float RandomItem;

	public float CHASESPEED
	{
		get
		{
			return ChaseSpeed;
		}
		set
		{
			ChaseSpeed = value;
		}
	}


	void Start()
	{
		PlayerDir = Vector3.zero;
		RandomItem = Random.Range(0, 10000.0f) / 100.0f;
		this.gameObject.tag = TAG_NAME.Enemy.ToString();
		Health = MAXHP;
	}
	
	void Update()
	{
		PlayerDirMove();
		PlayerDirRotation(PlayerDir, Vector3.up);

		//아주 미세하게 계속해서 적 속도 증가
		ChaseSpeed += Time.deltaTime * 0.1f;
	}

	protected virtual void PlayerDirMove()
	{
		PlayerDir = LoadData.Player.transform.position - this.transform.position;
		PlayerDir.Normalize();

		//플레이어 방향으로 이동
		this.transform.position += PlayerDir * ChaseSpeed * Time.deltaTime;
	}

	protected void PlayerDirRotation(Vector3 pDir, Vector3 eDir)
	{
		pDir.Normalize();
		eDir.Normalize();

		float angle = 0;
		Vector3 cross = Vector3.zero;
		//플레이어 방향으로 머리 회전
		//현재 머리의 방향은 up벡터
		cross = Vector3.Cross(eDir, pDir);
		angle = Vector3.Dot(pDir, eDir);
		angle = Mathf.Acos(angle);


		angle = Mathf.Rad2Deg * angle;

		//외적으로 축을 구해서 그 축에 회전값을 줘서 돌림
		transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	}

	void SpawnItem()
	{
		if (RandomItem < SPAWN_PERCENT)
		{
			Instantiate(LoadData.Item, this.transform.position, Quaternion.identity);
		}
	}


	public virtual void SpawnParticle()
	{
		//Instantiate(LoadData.EnemyParticleTriangle, this.transform.position, Quaternion.identity);
		ParticleManager.Instance.ParticleCreate(PARTICLE.EnemyTriangle, this.transform.position, 0.7f);
	}

	public virtual void CollisionProcess()
	{
		SpawnParticle();
		SpawnItem();
		EnemyManager.Instance.OnDeath(this.gameObject);
		Destroy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (TagCheck.GetColl(this.tag, collision.tag))
		{
			if (collision.gameObject.CompareTag(TAG_NAME.PlayerBullet.ToString()))
			{
				//이 부분은 생각을 해봐야 할듯..
				//일단 통일이 가능하게 하려면 체력 스크립트를 따로 짜야된다는 생각.
				CalculateHealth(collision.GetComponent<DefaultBullet>().BULLETDAMAGE);
			}
		}
	}

	public virtual void CalculateHealth(float damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			CollisionProcess();
		}
	}

}
