using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreater1 : MonoBehaviour {

	//float BulletFireSpeed;
	//float MaxFireSpeed;
	//float RotateDegree = 0;

	//GameObject Bullet;
	//GameObject BigBullet;
	//GameObject OrbitBullet;
	//GameObject ChaseBullet;
	//GameObject RoundOneBullet;

	//GameObject Orbit;

	//delegate void FireBulletFunc();
	//FireBulletFunc CurFireBullet;

	//private void Start()
	//{
	//	Bullet = Resources.Load("Prefabs/Bullet/Bullet") as GameObject;
	//	BigBullet = Resources.Load("Prefabs/Bullet/BigBullet") as GameObject;
	//	OrbitBullet = Resources.Load("Prefabs/Bullet/OrbitBullet") as GameObject;
	//	ChaseBullet = Resources.Load("Prefabs/Bullet/ChaseBullet") as GameObject;
	//	RoundOneBullet = Resources.Load("Prefabs/Bullet/OneRoundBullet") as GameObject;
	//	Orbit = Instantiate(OrbitBullet);
	//	Orbit.SetActive(false);
	//	MaxFireSpeed = 0.2f;
	//	CurFireBullet = DefaultMissile;
	//}

	//private void Update()
	//{
	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > MaxFireSpeed)
	//	{
	//		CurFireBullet();
	//		BulletFireSpeed = 0;
	//	}
	//}

	//public void BulletChange(BULLET_TYPE bullet)
	//{
	//	CurFireBullet = FireChange(bullet);
	//}

	//FireBulletFunc FireChange(BULLET_TYPE bullet)
	//{
	//	Orbit.SetActive(false);

	//	switch (bullet)
	//	{
	//		case BULLET_TYPE.BT_DEFAULT:
	//			MaxFireSpeed = 0.2f;
	//			return DefaultMissile;
	//		case BULLET_TYPE.BT_BIG:
	//			MaxFireSpeed = 1.5f;
	//			return BigMissile;
	//		case BULLET_TYPE.BT_EIGHTDIR:
	//			MaxFireSpeed = 1.0f;
	//			return EightDirMissile;
	//		case BULLET_TYPE.BT_ORBIT:
	//			MaxFireSpeed = 0f;
	//			Orbit.SetActive(true);
	//			return OrbitMissile;
	//		case BULLET_TYPE.BT_ONEROUND:
	//			MaxFireSpeed = 0.1f;
	//			return OneRotationMissile;
	//		case BULLET_TYPE.BT_CHASE:
	//			MaxFireSpeed = 0.25f;
	//			return ChaserMissile;
	//		default:
	//			return null;
	//	}
	//}

	//void DefaultMissile()
	//{
	//	Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
	//}

	//void BigMissile()
	//{
	//	Instantiate(BigBullet, this.gameObject.transform.position, Quaternion.identity);
	//}

	//void EightDirMissile()
	//{
	//	for (int i = 0; i < 8; i++)
	//	{
	//		GameObject spawn_bullet = Instantiate(RoundOneBullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
	//		spawn_bullet.transform.GetComponentInChildren<OneRoundBullet>().BulletDir = Quaternion.Euler(0, 0, 45.0f * i) * Vector3.up;
	//	}
	//}

	//void OrbitMissile()
	//{
	//	Orbit.transform.position = this.transform.position;
	//}

	//void OneRotationMissile()
	//{
	//	GameObject spawn_bullet = Instantiate(RoundOneBullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
	//	spawn_bullet.transform.GetComponentInChildren<OneRoundBullet>().BulletDir = Quaternion.Euler(0, 0, RotateDegree += 22.5f) * Vector3.up;
	//}

	//void ChaserMissile()
	//{
	//	Instantiate(ChaseBullet, this.gameObject.transform.position, Quaternion.identity);
	//}
}
