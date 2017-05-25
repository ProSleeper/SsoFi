using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGenerator : BulletGenerator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.5f;
		Bullet = Resources.Load("Prefabs/Bullet/BigBullet") as GameObject;
	}
}
