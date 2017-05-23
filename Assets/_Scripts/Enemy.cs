using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	

	public float chaseSpeed;

	protected GameObject player;
	protected Vector3 playerDir;
	protected GameObject Item;

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
		PlayerDirMove();
		PlayerDirRotation(playerDir, Vector3.up);

		//아주 미세하게 계속해서 적 속도 증가
		chaseSpeed += Time.deltaTime * 0.1f;
	}

	virtual protected void PlayerDirMove()
	{
		playerDir = (player.transform.position - this.transform.position).normalized;

		//플레이어 방향으로 이동
		this.transform.position += playerDir * chaseSpeed * Time.deltaTime;
	}

	protected void PlayerDirRotation(Vector3 pDir, Vector3 uDir)
	{

		pDir.Normalize();
		uDir.Normalize();

		float angle = 0;
		Vector3 cross = Vector3.zero;
		//플레이어 방향으로 머리 회전
		//현재 머리의 방향은 up벡터
		angle = Vector3.Dot(pDir, uDir);
		cross = Vector3.Cross(uDir, pDir);
		angle = Mathf.Acos(angle);


		angle = Mathf.Rad2Deg * angle;

		//외적으로 축을 구해서 그 축에 회전값을 줘서 돌림
		transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	}

	void SpawnItem()
	{
		if (Random.Range(0, 100.0f) < 1.0f)
		{
			Instantiate(Item, this.transform.position, Quaternion.identity);
		}
	}

	bool Vec3Lenth(Vector3 v)
	{
		return (v.x + v.y + v.z) > 0.0f ? true : false;
	}

	private void OnDestroy()
	{
		SpawnItem();
		ScoreManager.Instance.AddScore();
	}
}
