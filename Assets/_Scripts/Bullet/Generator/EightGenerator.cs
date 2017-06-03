using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightGenerator : OneRotateGenerator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.0f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/OneBulletRotate") as GameObject;
	}

	public override void FireBullet()
	{
		for (int i = 0; i < 8; i++)
		{
			GameObject spawn_bullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			spawn_bullet.transform.localScale = BulletSize;
			spawn_bullet.GetComponent<OneRotateBullet>().BULLETSPEED = MoveSpeed;
			spawn_bullet.transform.GetComponent<OneRotateBullet>().BulletDir = Quaternion.Euler(0, 0, AugmentDegree * i) * Vector3.right;
			spawn_bullet.tag = this.tag;
		}
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value)
	{
		BulletSetting(bulletSize, moveSpeed, fireSpeed);
		AugmentDegree = value;
	}


}
