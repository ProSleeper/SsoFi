using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGenerator : Generator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.5f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/BigBullet") as GameObject;
	}
}
