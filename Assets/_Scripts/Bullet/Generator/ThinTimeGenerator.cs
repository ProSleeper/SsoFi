using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinTimeGenerator : Generator
{

	float BTime;
	float BScope;
	void Start()
	{
		Bullet = Resources.Load("Prefabs/Bullet/Entity/ThinTimeBullet") as GameObject;
	}

	public override void FireMissile()
	{
		GameObject temp = Instantiate(Bullet, this.transform.position, Quaternion.identity);
		temp.GetComponent<ThinTimeBullet>().BULLETSPEED = MoveSpeed;
		temp.GetComponent<ThinTimeBullet>().BombTime = BTime;
		temp.GetComponent<ThinTimeBullet>().BombScope = BScope;
		temp.transform.localScale = BulletSize;
		temp.tag = this.tag;
		//Instantiate()
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value1, float value2)
	{
		BulletSetting(bulletSize, moveSpeed, fireSpeed);
		BTime = value1;
		BScope = value2;
	}
}
