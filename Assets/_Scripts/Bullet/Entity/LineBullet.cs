﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBullet : BigBullet
{
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//이건 개별로 이름 비교하는거고
		//if (collision.gameObject.tag.Equals(TAGNAME.Enemy.ToString()) || collision.gameObject.tag.Equals(TAGNAME.EnemyBullet.ToString()))

		//이건 해당 문자열이 태그에 들어있는지 판단 ex) EnemyBullet 태그일때 Enemy 혹은 Bullet 중 하나만 가지고 판단이 가능함
		//문제는 나중에 태그가 더 많아졌을때 의도치 않은 충돌이 일어날 수 있음 
		if (CollTag.GetColl(this.tag, collision.tag))
		{
			Vector3 distance = collision.transform.position - this.transform.position;
			float aa = collision.transform.GetComponent<CircleCollider2D>().radius * collision.transform.localScale.x;
			Vector3 reverseDistance = -(distance.normalized * aa);

			SpawnParticle(this.transform.position + distance + reverseDistance);
			//Destroy(this.transform.gameObject);
		}
	}

	public override float BulletPower()
	{
		BulletDamage = 15;
		return BulletDamage;
	}
}