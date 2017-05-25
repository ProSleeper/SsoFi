using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
	public float MaxFireSpeed;
	
	protected float RoundSpeed;
	protected float RotateDegree;
	protected float BulletFireSpeed;
	protected GameObject Bullet;
	

	void Start () {
		//MaxFireSpeed = 0.2f;
		Bullet = Resources.Load("Prefabs/Bullet/Bullet") as GameObject;
	}
	
	public virtual void Update () {
		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > MaxFireSpeed)
		{
			FireMissile();
			BulletFireSpeed = 0;
		}
	}

	public virtual void FireMissile()
	{
		Instantiate(Bullet, this.gameObject.transform.position, Quaternion.identity);
	}
}
