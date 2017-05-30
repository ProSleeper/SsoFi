﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : DefaultBullet
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (TagCheck.GetColl(this.tag, collision.tag))
		{
			Vector3 temp = collision.transform.position - this.transform.position;
			float radius = this.GetComponent<CircleCollider2D>().radius;

			ParticleManager.Instance.ParticleCreate(PARTICLE.EnemyTriangle, this.transform.position + temp.normalized * radius, 8);
			//SpawnParticle(this.transform.position + temp.normalized * radius);
			Debug.Log("빅충돌");
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (TagCheck.GetColl(this.tag, collision.tag))
		{
			Vector3 temp = collision.transform.position - this.transform.position;
			float radius = this.GetComponent<CircleCollider2D>().radius;

			ParticleManager.Instance.ParticleCreate(PARTICLE.EnemyTriangle, this.transform.position + temp.normalized * radius, 8);
			//SpawnParticle(this.transform.position + temp.normalized * radius);
			Debug.Log("빅충돌");
		}
	}
}
