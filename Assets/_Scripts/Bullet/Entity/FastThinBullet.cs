using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastThinBullet : DefaultBullet
{
	public override float BulletPower()
	{
		BulletDamage = 5;
		return BulletDamage;
	}
}
