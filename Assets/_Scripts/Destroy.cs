using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	public GameObject Item;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Bullet"))
		{
			Destroy(collision.gameObject);
			Destroy(this.gameObject);

			if (Random.Range(0, 100.0f) < 5.0f)
			{
				Instantiate(Item, this.transform.position, Quaternion.identity);
			}
			
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
