using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoadData
{
	public static GameObject[] ArrayParticle;


	public static GameObject ThinSubBullet;
	public static GameObject Player;
	public static GameObject Item;

	public static void OnDataLoad()
	{
		Player = GameObject.Find("Player");
		Item = Resources.Load("Prefabs/Item/Item") as GameObject;

		ThinSubBullet = Resources.Load("Prefabs/Bullet/Entity/SubEntity/ExplosionScope") as GameObject;

		ArrayParticle = Resources.LoadAll<GameObject>("Prefabs/Particle");
	}
}