using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.transform.parent == null)
		{
			Destroy(collision.gameObject);
		}
		else
		{
			Destroy(collision.gameObject.transform.parent.gameObject);
		}
		
	}
}
