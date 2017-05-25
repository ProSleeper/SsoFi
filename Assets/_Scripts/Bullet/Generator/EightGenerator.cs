using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightGenerator : BulletGenerator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.0f;
		Bullet = Resources.Load("Prefabs/Bullet/OneBulletRotate") as GameObject;
	}

	public override void FireMissile()
	{
		for (int i = 0; i < 8; i++)
		{
			GameObject spawn_bullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			spawn_bullet.transform.GetComponentInChildren<OneRotateBullet>().BulletDir = Quaternion.Euler(0, 0, 45.0f * i) * Vector3.up;
		}
	}
}
