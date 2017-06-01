using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomb : DefaultBullet
{

	float dTime;
	float StartRadius;
	public float EndRadius;
	CircleCollider2D Coll;

	void Start ()
	{
		dTime = 0;
		StartRadius = 1;
		//EndRadius = 4;
		Coll = this.GetComponent<CircleCollider2D>();
	}

	private void Update()
	{
		dTime += Time.deltaTime;
		Coll.radius = Mathf.Lerp(StartRadius, EndRadius, dTime / 1);

		if (dTime > 1)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}
}
