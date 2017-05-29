using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRotateGenerator : Generator
{

	protected float AugmentDegree = 22.5f;
	protected float CurDegree;

	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 0.1f;
		CurDegree = 0;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/OneBulletRotate") as GameObject;
	}

	public override void FireMissile()
	{
		GameObject spawn_bullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
		spawn_bullet.transform.localScale = BulletSize;
		spawn_bullet.GetComponent<OneRotateBullet>().BULLETSPEED = MoveSpeed;
		spawn_bullet.transform.GetComponent<OneRotateBullet>().BulletDir = Quaternion.Euler(0, 0, CurDegree += AugmentDegree) * Vector3.up;
		spawn_bullet.tag = this.tag;
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value)
	{
		BulletSetting(bulletSize, moveSpeed, fireSpeed);
		AugmentDegree = value;
	}
}
