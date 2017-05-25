using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	const float SPAWN_PERCENT = 100.0f;

	//static GameObject DeadPrefab;
	//protected static GameObject Player;
	//protected static GameObject Item;
	//static GameObject DestroyParticle;
	protected Vector3 PlayerDir;

	public float ChaseSpeed;
	float RandomItem;


	//static void OnLoad()
	//{
	//	Player = GameObject.Find("Player");
	//	Item = Resources.Load("Prefabs/Item") as GameObject;
	//	DeadPrefab = Resources.Load("Prefabs/Enemy/EnemyParticleTriangle") as GameObject;
	//}
	//private void Awake()
	//{
	//	OnLoad();
	//}
	// Use this for initialization
	void Start()
	{
		//DestroyParticle = Instantiate(OnLoad.DeadPrefab);
		//DestroyParticle.SetActive(false);
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
		PlayerDir = OnLoad.Player.transform.position - this.transform.position;
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
			Instantiate(OnLoad.Item, this.transform.position, Quaternion.identity);
		}
	}

	protected virtual void CollisionProcess()
	{
		//파티클 생성
		//이게 아니라면 파티클 매니저를 만들어서 여기서는 생성하라고 명령만해주고 실제 관리는 매니저를 통해서 하는 것도 괜찮을듯
		
		//파티클 생성코드 #1.. 어떤게 더 나은지 궁금함.. 개인적으로는 생성하는것보다는 생성해놓고 활성화 하는게 소모값이 적다고 생각됨
		Instantiate(OnLoad.DeadPrefab, this.transform.position, Quaternion.identity);
		//par.GetComponent<ParticleSystem>().Play();	//Play On Awake를 키면 생략 가능

		//파티클 생성코드 #2
		//미리 생성한후 비활성화 상태에서 충돌할때 활성화후 위치 맞추고 파티클 재생
		//DestroyParticle.SetActive(true);
		//DestroyParticle.transform.position = this.transform.position;
		//DestroyParticle.GetComponent<ParticleSystem>().Play();

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
