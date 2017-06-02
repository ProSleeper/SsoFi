using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Enemy에서 사용할 것들.. 한번씩만 로드하면 되는데 Enemy 코드에 넣으면 생성 될때마다 하기에 이렇게 둠..
//나중엔 이런종류를 한군데다가 모아서 한번에 로드시키는게 좋을듯
public static class LoadData
{
	public static GameObject EnemyParticle;
	public static GameObject BulletParticle;
	public static GameObject ThinBulletParticle;
	public static GameObject ThinSubBullet;
	public static GameObject Player;
	public static GameObject Item;

	public static void OnEnemyDataLoad()
	{
		Player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item/Item") as GameObject;
		ThinSubBullet = Resources.Load("Prefabs/Bullet/Entity/SubEntity/ExplosionScope") as GameObject;

		EnemyParticle = Resources.Load("Prefabs/Enemy/EnemyParticleTriangle") as GameObject;
		BulletParticle = Resources.Load("Prefabs/Bullet/BulletParticle") as GameObject;
		ThinBulletParticle = Resources.Load("Prefabs/Bullet/ThinBulletParticle") as GameObject;
	}

	
}
