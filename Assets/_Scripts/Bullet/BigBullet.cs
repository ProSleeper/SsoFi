using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : DefaultBullet
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			collision.gameObject.GetComponent<Enemy>().SpawnItem();
			Destroy(collision.gameObject);
		}
	}
}
