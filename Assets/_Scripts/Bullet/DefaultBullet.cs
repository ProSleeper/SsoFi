using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{
	public float BulletSpeed;
	[HideInInspector]
	public Vector3 BulletDir = Vector3.zero;

    // Use this for initialization
    void Start()
    {
		//BulletDir = Vector3.zero - this.transform.position;
		//if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		//{
		//	BulletDir = Vector3.up;
		//}
	}

    // Update is called once per frame
    void Update()
    {
		EnemyChase();
	}

	public void EnemyChase()
	{
		BulletDir.Normalize();
		this.transform.position += BulletDir * BulletSpeed * Time.deltaTime;
		Vector3 cross = Vector3.zero;
		float angle = 0;


		cross = Vector3.Cross(Vector3.right, BulletDir);
		angle = Vector3.Dot(BulletDir, Vector3.right);
		angle = Mathf.Acos(angle);
		angle = Mathf.Rad2Deg * angle;

		this.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			collision.gameObject.GetComponent<Enemy>().SpawnItem();
			Destroy(collision.gameObject);
			Destroy(this.transform.parent.gameObject);
		}
	}
}
