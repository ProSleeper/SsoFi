using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum MISSILE_TYPE
{
	MT_DEFAULT,
	MT_BIG,
	MT_ROUND,
	MT_EIGHTDIR,
	MT_ONEROUNT,
	MT_MAX
}


public class Fire : MonoBehaviour
{
	
	Vector3 BulletDir = Vector3.up;
	float BulletFireSpeed;
	float MaxBulletFireSpeed = 0.2f;
	[HideInInspector]
	public float RotateTime = 0;

	GameObject CurrentBullet;
	GameObject Bullet;
	GameObject BigBullet;
	GameObject RoundBullet;
	GameObject roundBullet;
	delegate void FireBulletFunc();
	FireBulletFunc CurFireBullet;
	event FireBulletFunc Active;

	FireBulletFunc[] ArrFire = new FireBulletFunc[(int)MISSILE_TYPE.MT_MAX];
	
	// Use this for initialization
	void Start()
	{
		//CurFireBullet = new FireBulletFunc(DefaultMissile);
		Bullet = Resources.Load("Prefabs/Bullet") as GameObject;
		BigBullet = Resources.Load("Prefabs/BigBullet") as GameObject;
		RoundBullet = Resources.Load("Prefabs/RoundBullet") as GameObject;

		roundBullet = Instantiate(RoundBullet, this.transform.position, Quaternion.identity) as GameObject;
		roundBullet.SetActive(false);
		
		ArrFire[0] = Missile1;
		ArrFire[1] = Missile2;
		ArrFire[2] = Missile3;
		ArrFire[3] = Missile4;
		ArrFire[4] = Missile5;

		Active = ArrFire[0];
		Active();

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
		CurFireBullet();
	}

	public void ChangeMissile(int mt)
	{
		Active = ArrFire[mt];
		Active();
	}

	public void Missile1()
	{
		roundBullet.SetActive(false);
		MaxBulletFireSpeed = 0.2f;
		CurrentBullet = Bullet;
		CurFireBullet = new FireBulletFunc(DefaultMissile);
	}

	public void Missile2()
	{
		roundBullet.SetActive(false);
		MaxBulletFireSpeed = 0.8f;
		CurrentBullet = BigBullet;
		//FireBullet = new FireBulletFunc(BigMissile);
		CurFireBullet = new FireBulletFunc(DefaultMissile);
	}

	void Missile3()
	{
		roundBullet.SetActive(false);
		CurFireBullet = new FireBulletFunc(RotationMissile);
		
	}

	void Missile4()
	{
		roundBullet.SetActive(true);
		CurFireBullet = new FireBulletFunc(RoundMissile);
	}

	void Missile5()
	{
		roundBullet.SetActive(false);
		CurFireBullet = new FireBulletFunc(RotationOneMissile);
	}

	bool Vec3Lenth(Vector3 v)
	{
		return (v.x + v.y + v.z) > 0.0f ? true : false;
	}

	void DefaultMissile()
	{

		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > MaxBulletFireSpeed)
		{

			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;


			GameObject spawnEnemy = Instantiate(CurrentBullet, bulletPos, Quaternion.identity) as GameObject;




			float angle = Vector3.Dot(BulletDir, Vector3.right);
			Vector3 cross = Vector3.Cross(BulletDir, Vector3.right);
			float dosu = Mathf.Acos(angle);

			dosu = Mathf.Rad2Deg * dosu;

			//Debug.Log("Dir" + BulletDir + "  Cross" + cross);

			//외적을 구해서 외적의 순서가 
			if (Vec3Lenth(cross))
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(-dosu, Vector3.forward);
				
				//Quaternion.Lerp(transform.localRotation, Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back), 1);
			}
			else
			{
				spawnEnemy.transform.localRotation = Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back);
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
				spawnEnemy[i] = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;
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

	void RoundMissile()
	{

		roundBullet.transform.position = this.transform.position;
		roundBullet.transform.rotation = Quaternion.Euler(0, 0, (RotateTime++) * 1.5f);

	}
	float r = 22.5f;
	void RotationOneMissile()
	{
		
		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > 0.05f)
		{
			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;

			GameObject spawnEnemy = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;


			Quaternion v3Rotation = Quaternion.Euler(0f, 0f, r += 22.5f );  // 회전각 
			Vector3 v3Direction = Vector3.up; // 회전시킬 벡터(테스트용으로 world forward 썼음) 
			Vector3 v3RotatedDirection = v3Rotation * v3Direction;
			spawnEnemy.transform.right = v3RotatedDirection;
			spawnEnemy.GetComponent<BulletMove>().BulletDir = Vector3.right;//Vector3.up; 

			BulletFireSpeed = 0;
		}
	}

	void ChaserMissile()
	{

		BulletFireSpeed += Time.deltaTime;
		if (BulletFireSpeed > 0.1f)
		{
			Vector3 bulletPos = this.transform.position;
			bulletPos.z = 1;

			GameObject spawnEnemy = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;


			Quaternion v3Rotation = Quaternion.Euler(0f, 0f, r += 22.5f);  // 회전각 
			Vector3 v3Direction = Vector3.up; // 회전시킬 벡터(테스트용으로 world forward 썼음) 
			Vector3 v3RotatedDirection = v3Rotation * v3Direction;
			spawnEnemy.transform.right = v3RotatedDirection;
			spawnEnemy.GetComponent<BulletMove>().BulletDir = Vector3.right;//Vector3.up; 

			BulletFireSpeed = 0;
		}
	}


}
