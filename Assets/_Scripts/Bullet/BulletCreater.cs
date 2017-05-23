using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreater : MonoBehaviour {

	float BulletFireSpeed;
	float MaxFireSpeed;
	float RotateDegree = 0;

	GameObject Bullet;
	GameObject BigBullet;
	GameObject RoundBullet;
	GameObject ChaseBullet;
	GameObject RoundOneBullet;
	GameObject Round;

	delegate void FireBulletFunc();
	FireBulletFunc CurFireBullet;

	private void Start()
	{
		Bullet = Resources.Load("Prefabs/Bullet/Bullet") as GameObject;
		BigBullet = Resources.Load("Prefabs/Bullet/BigBullet") as GameObject;
		RoundBullet = Resources.Load("Prefabs/Bullet/RoundBullet") as GameObject;
		ChaseBullet = Resources.Load("Prefabs/Bullet/ChaseBullet") as GameObject;
		RoundOneBullet = Resources.Load("Prefabs/Bullet/OneRoundBullet") as GameObject;
		Round = Instantiate(RoundBullet);
		Round.SetActive(false);
		MaxFireSpeed = 0.2f;
		CurFireBullet = DefaultMissile;
	}

	private void Update()
	{
		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > MaxFireSpeed)
		{
			CurFireBullet();
			BulletFireSpeed = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Item"))
		{
			Destroy(collision.gameObject);
			CurFireBullet = FireChange((MISSILE_TYPE)Random.Range(0, 6));
		}
	}

	FireBulletFunc FireChange(MISSILE_TYPE mt)
	{
		Round.SetActive(false);

		switch (mt)
		{
			case MISSILE_TYPE.MT_DEFAULT:
				MaxFireSpeed = 0.2f;
				return DefaultMissile;
			case MISSILE_TYPE.MT_BIG:
				MaxFireSpeed = 1.5f;
				return BigMissile;
			case MISSILE_TYPE.MT_EIGHTDIR:
				MaxFireSpeed = 1.0f;
				return RotationMissile;
			case MISSILE_TYPE.MT_ROUND:
				MaxFireSpeed = 0f;
				Round.SetActive(true);
				return RoundMissile;
			case MISSILE_TYPE.MT_ONEROUND:
				MaxFireSpeed = 0.1f;
				return OneRotationMissile;
			case MISSILE_TYPE.MT_CHASE:
				MaxFireSpeed = 0.15f;
				return ChaserMissile;
			default:
				return null;
		}
	}

	void DefaultMissile()
	{
		Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
	}

	void BigMissile()
	{
		Instantiate(BigBullet, this.gameObject.transform.position, Quaternion.identity);
	}

	void RotationMissile()
	{
		for (int i = 0; i < 8; i++)
		{
			GameObject spawn_bullet = Instantiate(RoundOneBullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			spawn_bullet.transform.GetComponentInChildren<OneRoundBullet>().BulletDir = Quaternion.Euler(0, 0, 45.0f * i) * Vector3.up;
		}
	}

	void RoundMissile()
	{
		Round.transform.position = this.transform.position;
	}

	void OneRotationMissile()
	{
		GameObject spawn_bullet = Instantiate(RoundOneBullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
		spawn_bullet.transform.GetComponentInChildren<OneRoundBullet>().BulletDir = Quaternion.Euler(0, 0, RotateDegree += 22.5f) * Vector3.up;
	}

	void ChaserMissile()
	{
		Instantiate(ChaseBullet, this.gameObject.transform.position, Quaternion.identity);
	}
}
