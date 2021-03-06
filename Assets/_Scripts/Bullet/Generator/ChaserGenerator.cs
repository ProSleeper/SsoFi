﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGenerator : Generator
{
	void Start () {
		//MaxFireSpeed = 0.25f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/ChaseBullet") as GameObject;
		
	}
	
	public override void FireBullet()
	{
		GameObject temp = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
		temp.GetComponent<DefaultBullet>().BULLETSPEED = MoveSpeed;
		temp.transform.localScale = BulletSize;
		temp.tag = this.tag;
	}
}
