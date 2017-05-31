using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : DefaultBullet
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			Vector3 temp = collision.transform.position - this.transform.position;
			float radius = this.GetComponent<CircleCollider2D>().radius;

			SpawnParticle(this.transform.position + temp.normalized * radius);
			Debug.Log("빅충돌");
		}
	}

	//private void OnTriggerStay2D(Collider2D collision)
	//{
	//	if (OnLoad.GetColl(this.tag, collision.tag))
	//	{
	//		Vector3 temp = collision.transform.position - this.transform.position;
	//		float radius = this.GetComponent<CircleCollider2D>().radius;

	//		SpawnParticle(this.transform.position + temp.normalized * radius);
	//		Debug.Log("빅충돌");
	//	}
	//}
}
