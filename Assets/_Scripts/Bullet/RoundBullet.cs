using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBullet : BigBullet
{
	public float RoundSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.position;
		this.transform.parent.transform.rotation = Quaternion.Euler(0, 0, (RoundSpeed++) * 1.2f);
	}
}
