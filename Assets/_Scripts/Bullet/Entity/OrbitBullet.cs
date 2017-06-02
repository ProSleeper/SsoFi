using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBullet : BigBullet
{
	
	// Update is called once per frame
	void Update () {
		
	}

	public override float BulletPower()
	{
		BulletDamage = 15;
		return BulletDamage;
	}
}
