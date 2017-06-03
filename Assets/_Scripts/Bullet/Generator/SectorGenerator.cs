using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorGenerator : OneRotateGenerator
{
	// Use this for initialization
	void Start () {
		//MaxFireSpeed = 1.0f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/SectorBullet") as GameObject;
	}

	public override void FireBullet()
	{
		Vector3 temp = (Vector3.zero - this.transform.position).normalized;
		if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		{
			temp = Vector3.up;
		}
		for (int i = -1; i < 2; i++)
		{
			GameObject spawn_bullet = Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			spawn_bullet.transform.localScale = BulletSize;
			spawn_bullet.GetComponent<SectorBullet>().BULLETSPEED = MoveSpeed;
			//spawn_bullet.GetComponent<SectorBullet>().BulletDir = temp + (new Vector3(0.1f, 0.1f, 0) * i);

			spawn_bullet.GetComponent<SectorBullet>().BulletDir = Quaternion.Euler(0, 0, AugmentDegree * i) * temp;
			
			//Debug.Log(temp + (new Vector3(0.1f, 0.1f, 0) * i));
			//spawn_bullet.transform.rota = Quaternion.Euler(0, 0, 10 * i);
			spawn_bullet.tag = this.tag;
		}
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value)
	{
		BulletSetting(bulletSize, moveSpeed, fireSpeed);
		AugmentDegree = value;
	}


}
