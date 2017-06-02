using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightDirBullet : DefaultBullet
{
	public override float BulletPower()
	{
		BulletDamage = 20;
		return BulletDamage;
	}
}
