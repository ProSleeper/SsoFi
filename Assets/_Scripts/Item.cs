using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BULLET_TYPE
{
	BT_DEFAULT,
	BT_BIG,
	BT_EIGHTDIR,
	BT_ORBIT,
	BT_ONEROUND,
	BT_CHASE,
	BT_MAX
}

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
		if (collision.gameObject.tag.Equals(TAG_NAME.Player.ToString()))
		{
			collision.gameObject.GetComponent<BulletCreater>().BulletChange(RandomBullet);

			Destroy(this.gameObject);
		}
	}
}
