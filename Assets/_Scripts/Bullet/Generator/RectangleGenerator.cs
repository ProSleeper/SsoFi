using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleGenerator : Generator
{
	void Start()
	{
		//MaxFireSpeed = 1.5f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/RectangleBullet") as GameObject;
	}
}
