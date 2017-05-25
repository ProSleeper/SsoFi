using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserGenerator : BulletGenerator
{
	void Start () {
		//MaxFireSpeed = 0.25f;
		Bullet = Resources.Load("Prefabs/Bullet/ChaseBullet") as GameObject;
	}
	
	public override void FireMissile()
	{
		Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
	}
}
