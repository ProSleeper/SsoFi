using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBullet : BigBullet
{
	public float RoundSpeed;
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position;
		this.transform.parent.transform.rotation = Quaternion.Euler(0, 0, (RoundSpeed++) * 1.2f);
	}
}
