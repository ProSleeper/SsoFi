using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinTimeBullet : DefaultBullet
{
	[HideInInspector]
	public float BombTime;
	public float BombScope;

	void Start()
	{
		BulletDir = Vector3.zero - this.transform.position;
		if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		{
			BulletDir = Vector3.up;
		}
		Invoke("SuicideBullet", BombTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (TagCheck.GetColl(this.tag, collision.tag))
		{
			SuicideBullet();
		}
	}

	void SuicideBullet()
	{
		GameObject temp = Instantiate(LoadData.ThinSubBullet, this.transform.position, Quaternion.identity);
		temp.GetComponent<SuicideBomb>().EndRadius = BombScope;
		temp.tag = this.tag;
		ParticleManager.Instance.ParticleCreate(PARTICLE.ThinBullet, this.transform.position, 2);
		Destroy(this.transform.gameObject);
	}

	


}
