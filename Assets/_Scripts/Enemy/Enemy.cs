using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	const float SPAWN_PERCENT = 1.0f;

	GameObject DeadParticle;

	public float ChaseSpeed;

	protected GameObject Player;
	protected Vector3 PlayerDir;
	protected GameObject Item;

	float RandomItem;

	// Use this for initialization
	void Start()
	{
		Player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item") as GameObject;
		DeadParticle = Resources.Load("Prefabs/Enemy/EnemyParticleTriangle") as GameObject;
		PlayerDir = Vector3.zero;
		RandomItem = Random.Range(0, 10000.0f) / 100.0f;
		this.gameObject.tag = TAG_NAME.Enemy.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		PlayerDirMove();
		PlayerDirRotation(PlayerDir, Vector3.up);

		//아주 미세하게 계속해서 적 속도 증가
		ChaseSpeed += Time.deltaTime * 0.1f;
	}

	protected virtual void PlayerDirMove()
	{
		PlayerDir = Player.transform.position - this.transform.position;
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
			Instantiate(Item, this.transform.position, Quaternion.identity);
		}
	}

	protected virtual void CollisionProcess()
	{
		//파티클 생성
		//이게 아니라면 파티클 매니저를 만들어서 여기서는 생성하라고 명령만해주고 실제 관리는 매니저를 통해서 하는 것도 괜찮을듯
		GameObject par = Instantiate(DeadParticle, this.transform.position, Quaternion.identity) as GameObject;
		par.GetComponent<ParticleSystem>().Play();

		//아이템 생성
		SpawnItem();

		//점수 증가
		//Debug.Log("충돌");
		EnemyManager.Instance.OnDeath();
		Destroy(this.gameObject);
		//EnemyManager.Instance.RemoveEnemy(this.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(TAG_NAME.PlayerBullet.ToString()))
		{
			CollisionProcess();
		}
	}
}
