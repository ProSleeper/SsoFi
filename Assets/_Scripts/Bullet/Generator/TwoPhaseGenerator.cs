using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPhaseGenerator : Generator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.5f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/TwoPhaseBullet") as GameObject;
	}
}
