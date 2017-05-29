using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{

	protected Vector3 BulletSize = Vector3.zero;
	protected float FireSpeed;
	protected float MoveSpeed;

	protected float Curtime;
	protected GameObject Bullet = null;
	
	void Start()
	{
		FireSpeed = 0.2f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/Bullet") as GameObject;
	}

	void Update()
	{
		Curtime += Time.deltaTime;
		if (Curtime > FireSpeed)
		{
			FireMissile();
			Curtime = 0;
		}
	}

	public virtual void FireMissile()
	{
		GameObject temp = Instantiate(Bullet, this.transform.position, Quaternion.identity);
		temp.GetComponent<DefaultBullet>().BULLETSPEED = MoveSpeed;
		temp.transform.localScale = BulletSize;
		temp.tag = this.tag;
		//Instantiate()
	}

	public virtual void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed)
	{
		BulletSize = bulletSize;
		MoveSpeed = moveSpeed;
		FireSpeed = fireSpeed;
	}

	public virtual void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value)
	{
	}

	public virtual void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value1, float value2)
	{
	}
}
