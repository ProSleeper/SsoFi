using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorBullet : DefaultBullet
{
	// Use this for initialization
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

	// Update is called once per frame
}
