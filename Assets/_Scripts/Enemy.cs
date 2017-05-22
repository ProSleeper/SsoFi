using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float chaseSpeed;

	GameObject player;
	Vector3 playerDir;
	GameObject Item;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item") as GameObject;
		playerDir = new Vector3(0, 1, 0);
	}

	// Update is called once per frame
	void Update()
	{
		PlayerChase();
	}

	void PlayerChase()
	{
		//플레이어 방향으로 이동
		playerDir = (player.transform.position - this.transform.position).normalized;
		this.transform.position += playerDir * chaseSpeed * Time.deltaTime;


		//플레이어 방향으로 머리 회전
		//현재 머리의 방향은 up벡터
		float angle = Vector3.Dot(playerDir, Vector3.up);
		Vector3 cross = Vector3.Cross(Vector3.up, playerDir);
		angle = Mathf.Acos(angle);


		angle = Mathf.Rad2Deg * angle;

		//외적으로 축을 구해서 그 축에 
		transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
		

		chaseSpeed += Time.deltaTime * 0.1f;
	}

	//이렇게 처리하거나 다른 스크립트에서 충돌처리하면 거기서 함수 만들어서 불러주기
	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.gameObject.tag.Equals("Bullet"))
	//	{
	//		if (Random.Range(0, 100.0f) < 5.0f)
	//		{
	//			Instantiate(Item, this.transform.position, Quaternion.identity);
	//		}
	//	}
	//}

	public void SpawnItem()
	{
		if (Random.Range(0, 100.0f) < 5.0f)
		{
			Instantiate(Item, this.transform.position, Quaternion.identity);
		}
	}

	bool Vec3Lenth(Vector3 v)
	{
		return (v.x + v.y + v.z) > 0.0f ? true : false;
	}
}
