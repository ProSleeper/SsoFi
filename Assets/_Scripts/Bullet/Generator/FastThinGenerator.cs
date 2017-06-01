using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastThinGenerator : Generator
{
	void Start()
	{
		//FireSpeed = 0.1f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/FastThinBullet") as GameObject;
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed)
	{
		BulletSize = bulletSize;
		MoveSpeed = moveSpeed;
		FireSpeed = fireSpeed;
	}
}
