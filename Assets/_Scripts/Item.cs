using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public float RotSpeed;
	float Speed;
	BULLET_TYPE RandomBullet;
	
	private void Start()
	{
		this.gameObject.tag = TAG_NAME.Item.ToString();
		RandomBullet = (BULLET_TYPE)(Random.Range(0, 600) / 100);
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Euler(0, 0, Speed += RotSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			collision.gameObject.GetComponent<PlayerBulletCreator>().BulletGeneratorChange(RandomBullet);
			//collision.gameObject.GetComponentInChildren<PlayerGun>().BulletGeneratorChange(RandomBullet);
			Destroy(this.gameObject);
		}
	}
}
