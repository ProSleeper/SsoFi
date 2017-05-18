using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);
		}

		if (collision.gameObject.CompareTag("BigBullet"))
		{
			Destroy(this.gameObject);
		}

		if (collision.gameObject.CompareTag("RoundBullet"))
		{
			
			//this.gameObject.GetComponent<>
		}
	}

}
