using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBullet : MonoBehaviour {

	Transform EnemyDir = null;
	bool IsCrash = false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Enemy") && EnemyDir == null)
		{
			EnemyDir = collision.transform;
			IsCrash = true;
		}
	}



	private void Update()
	{
		if (IsCrash && EnemyDir != null)
		{
			this.transform.parent.GetComponent<DefaultBullet>().BulletDir = EnemyDir.transform.position - this.transform.position;
		}
		
	}
}
