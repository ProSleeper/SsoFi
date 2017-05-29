using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorBullet : DefaultBullet
{
	void Awake()
    {
		BulletDir = Vector3.zero - this.transform.position;
		if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		{
			BulletDir = Vector3.up;
		}
	}
	private void Start()
	{
		
	}

}
