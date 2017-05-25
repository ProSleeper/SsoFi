using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRotateGenerator : BulletGenerator
{
	
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 0.1f;
		RotateDegree = 22.5f;
		Bullet = Resources.Load("Prefabs/Bullet/OneBulletRotate") as GameObject;
	}

	public override void FireMissile()
	{
		GameObject spawn_bullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
		spawn_bullet.transform.GetComponentInChildren<OneRotateBullet>().BulletDir = Quaternion.Euler(0, 0, RoundSpeed += RotateDegree) * Vector3.up;
	}
}
