using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{


	Vector3 NextTrans;
	Vector3 PrevTrans;
	Vector3 BulletDir = Vector3.up;
	float BulletFireSpeed;
	GameObject bullet;
	GameObject bigBullet;
	delegate void FireBulletFunc();
	FireBulletFunc FireBullet;
	public Button[] btn;
	// Use this for initialization
	void Start()
	{
		FireBullet = new FireBulletFunc(DefaultMissile);
		bullet = Resources.Load("Prefabs/Bullet") as GameObject;
		bigBullet = Resources.Load("Prefabs/BigBullet") as GameObject;

		btn[0].onClick.AddListener(Missile1);
		btn[1].onClick.AddListener(Missile2);
		btn[2].onClick.AddListener(Missile3);
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButton(0))
		{
			BulletDir = Vector3.zero - this.transform.position;
			BulletDir.Normalize();
			if (BulletDir == Vector3.zero)
			{
				BulletDir = Vector3.up;
			}
		}

		FireBullet();
		//if (Input.GetKeyDown(KeyCode.Space))


		PrevTrans = this.transform.position;
	}

	public void Missile1()
	{
		FireBullet = new FireBulletFunc(DefaultMissile);
	}

	public void Missile2()
	{
		FireBullet = new FireBulletFunc(BigMissile);
	}

	void Missile3()
	{
		FireBullet = new FireBulletFunc(RotationMissile);
	}

	bool Vec3Lenth(Vector3 v)
	{
		return (v.x + v.y + v.z) > 0.0f ? true : false;
	}

	void DefaultMissile()
	{

		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > 0.2f)
		{

			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;


			GameObject spawnEnemy = Instantiate(bullet, bulletPos, Quaternion.identity) as GameObject;




			float angle = Vector3.Dot(BulletDir, Vector3.right);

			Vector3 cross = Vector3.Cross(Vector3.right, BulletDir);
			float dosu = Mathf.Acos(angle);


			dosu = Mathf.Rad2Deg * dosu;

			//Debug.Log(cross);

			//외적을 구해서 외적의 순서가 
			if (Vec3Lenth(cross))
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back);
				//Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back), 1);
			}
			else
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(-dosu, Vector3.forward);
				//Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(-dosu, Vector3.forward), 1);
			}

			spawnEnemy.GetComponent<BulletMove>().BulletDir = Vector3.right;
			BulletFireSpeed = 0;
		}
	}

	void BigMissile()
	{

		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > 0.8f)
		{
			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;


			GameObject spawnEnemy = Instantiate(bigBullet, bulletPos, Quaternion.identity) as GameObject;




			float angle = Vector3.Dot(BulletDir, Vector3.right);

			Vector3 cross = Vector3.Cross(Vector3.right, BulletDir);
			float dosu = Mathf.Acos(angle);


			dosu = Mathf.Rad2Deg * dosu;

			//Debug.Log(cross);

			//외적을 구해서 외적의 순서가
			if (Vec3Lenth(cross))
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back);
				//Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back), 1);
			}
			else
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(-dosu, Vector3.forward);
				//Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(-dosu, Vector3.forward), 1);
			}

			spawnEnemy.GetComponent<BulletMove>().BulletDir = Vector3.right;
			BulletFireSpeed = 0;
		}
	}

	void RotationMissile()
	{
		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > 0.5f)
		{
			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;

			GameObject[] spawnEnemy = new GameObject[8];
			for (int i = 0; i < 8; i++)
			{
				spawnEnemy[i] = Instantiate(bullet, bulletPos, Quaternion.identity) as GameObject;
			}

			for (int i = 0; i < 8; i++)
			{
				Quaternion v3Rotation = Quaternion.Euler(0f, 0f, 45f * i);  // 회전각 
				Vector3 v3Direction = Vector3.up; // 회전시킬 벡터(테스트용으로 world forward 썼음) 
				Vector3 v3RotatedDirection = v3Rotation * v3Direction;
				spawnEnemy[i].transform.right = v3RotatedDirection;
				spawnEnemy[i].GetComponent<BulletMove>().BulletDir = Vector3.right;//Vector3.up; 
			}
			BulletFireSpeed = 0;
		}
	}
}
