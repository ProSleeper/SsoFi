using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//public enum MISSILE_TYPE
//{
//	MT_DEFAULT,
//	MT_BIG,
//	MT_EIGHTDIR,
//	MT_ROUND,
//	MT_ONEROUND,
//	MT_MAX
//}

public class BulletKind : MonoBehaviour
{
	//Vector3 mouseMovePos;
	//Vector3 mouseClickPos;
	//Vector3 distance;

	//public Button btn;


	//Vector3 BulletDir = Vector3.up;
	//float BulletFireSpeed;
	//float MaxBulletFireSpeed = 0.2f;
	//int DirCount = 0;
	//[HideInInspector]
	//public float RotateTime = 0;

	//GameObject CurrentBullet;
	//GameObject Bullet;
	//GameObject BigBullet;
	//GameObject RoundBullet;
	//GameObject roundBullet;
	//delegate void FireBulletFunc();
	//FireBulletFunc CurFireBullet;
	//event FireBulletFunc Active;

	//FireBulletFunc[] ArrFire = new FireBulletFunc[(int)MISSILE_TYPE.MT_MAX];


	//void Start()
	//{

	//	btn.onClick.AddListener(Restart);
	//	btn.gameObject.SetActive(false);

	//	Bullet = Resources.Load("Prefabs/Bullet/Bullet") as GameObject;
	//	BigBullet = Resources.Load("Prefabs/Bullet/BigBullet") as GameObject;
	//	RoundBullet = Resources.Load("Prefabs/Bullet/RoundBullet") as GameObject;

	//	roundBullet = Instantiate(RoundBullet, this.transform.position, Quaternion.identity) as GameObject;
	//	roundBullet.SetActive(false);

	//	ArrFire[(int)MISSILE_TYPE.MT_DEFAULT] = Missile1;
	//	ArrFire[(int)MISSILE_TYPE.MT_BIG] = Missile2;
	//	ArrFire[(int)MISSILE_TYPE.MT_EIGHTDIR] = Missile3;
	//	ArrFire[(int)MISSILE_TYPE.MT_ROUND] = Missile4;
	//	ArrFire[(int)MISSILE_TYPE.MT_ONEROUND] = Missile5;

	//	Active = ArrFire[4];
	//	Active();
	//}

	//Update is called once per frame

	//void Update()
	//{
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		mouseClickPos = Input.mousePosition;
	//		mouseClickPos = Camera.main.ScreenToWorldPoint(mouseClickPos);
	//		distance = this.gameObject.transform.position - mouseClickPos;
	//	}

	//	if (Input.GetMouseButton(0))
	//	{
	//		mouseMovePos = Input.mousePosition;
	//		mouseMovePos = Camera.main.ScreenToWorldPoint(mouseMovePos);
	//		this.transform.position = mouseMovePos + distance;

	//		ScreenLock();
	//	}

	//	미사일 방향은 항상 가운데로만 가게 하는 부분
	//	BulletDir = Vector3.zero - this.transform.position;
	//	BulletDir.Normalize();
	//	if (BulletDir == Vector3.zero)
	//	{
	//		BulletDir = Vector3.up;
	//	}

	//	CurFireBullet();
	//}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.gameObject.name.Equals("Enemy"))
	//	{
	//		Debug.Log("플레이어 충돌!");
	//		btn.gameObject.SetActive(true);
	//	}

	//	if (collision.gameObject.tag.Equals("Item"))
	//	{
	//		Destroy(collision.gameObject);
	//		ChangeMissile(Random.Range(0, 5));
	//	}
	//}

	//Update is called once per frame
	//void Restart()
	//{
	//	btn.gameObject.SetActive(false);
	//	SceneManager.LoadScene(0);
	//}

	//void ScreenLock()
	//{

	//	Vector3 MinPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
	//	Vector3 MaxPos = Camera.main.ScreenToWorldPoint(new Vector3(1440, 2560, 0));

	//	if (this.transform.position.x < MinPos.x)
	//	{
	//		this.transform.position = new Vector3(MinPos.x, this.transform.position.y, this.transform.position.z);
	//	}

	//	if (this.transform.position.x > MaxPos.x)
	//	{
	//		this.transform.position = new Vector3(MaxPos.x, this.transform.position.y, this.transform.position.z);
	//	}

	//	if (this.transform.position.y < MinPos.y)
	//	{
	//		this.transform.position = new Vector3(this.transform.position.x, MinPos.y, this.transform.position.z);
	//	}

	//	if (this.transform.position.y > MaxPos.y)
	//	{
	//		this.transform.position = new Vector3(this.transform.position.x, MaxPos.y, this.transform.position.z);
	//	}
	//}

	//public void ChangeMissile(int mt)
	//{
	//	Active = ArrFire[mt];
	//	Active();
	//}

	//public void Missile1()
	//{
	//	roundBullet.SetActive(false);
	//	CurrentBullet = Bullet;
	//	CurFireBullet = new FireBulletFunc(DefaultMissile);
	//}

	//public void Missile2()
	//{
	//	roundBullet.SetActive(false);
	//	CurrentBullet = BigBullet;
	//	CurFireBullet = new FireBulletFunc(BigMissile);
	//}

	//void Missile3()
	//{
	//	roundBullet.SetActive(false);
	//	CurFireBullet = new FireBulletFunc(RotationMissile);
	//}

	//void Missile4()
	//{
	//	roundBullet.SetActive(true);
	//	CurFireBullet = new FireBulletFunc(RoundMissile);
	//}

	//void Missile5()
	//{
	//	roundBullet.SetActive(false);
	//	CurFireBullet = new FireBulletFunc(RotationOneMissile);
	//}

	//bool Vec3Lenth(Vector3 v)
	//{
	//	return (v.x + v.y + v.z) > 0.0f ? true : false;
	//}

	//void DefaultMissile()
	//{
	//	MaxBulletFireSpeed = 0.2f;
	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > MaxBulletFireSpeed)
	//	{
	//		GameObject spawnEnemy = null;
	//		Vector3 bulletdir = Vector3.zero;
	//		Vector3 cross = Vector3.zero;
	//		float angle = 0;

	//		bulletdir = Vector3.zero - this.transform.position;
	//		spawnEnemy = Instantiate(CurrentBullet, this.transform.position, Quaternion.identity) as GameObject;
	//		spawnEnemy.GetComponent<Bullet>().BulletDir = bulletdir.normalized;

	//		cross = Vector3.Cross(Vector3.right, bulletdir.normalized);
	//		angle = Vector3.Dot(bulletdir.normalized, Vector3.right);
	//		angle = Mathf.Acos(angle);
	//		angle = Mathf.Rad2Deg * angle;


	//		외적을 구해서 외적의 순서가
	//		spawnEnemy.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	//		BulletFireSpeed = 0;
	//	}
	//}

	//void BigMissile()
	//{
	//	MaxBulletFireSpeed = 0.8f;
	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > MaxBulletFireSpeed)
	//	{

	//		GameObject spawnEnemy = null;
	//		Vector3 bulletdir = Vector3.zero;
	//		Vector3 cross = Vector3.zero;
	//		float angle = 0;

	//		bulletdir = Vector3.zero - this.transform.position;
	//		spawnEnemy = Instantiate(CurrentBullet, this.transform.position, Quaternion.identity) as GameObject;
	//		spawnEnemy.GetComponent<Bullet>().BulletDir = bulletdir.normalized;

	//		cross = Vector3.Cross(Vector3.right, bulletdir.normalized);
	//		angle = Vector3.Dot(bulletdir.normalized, Vector3.right);
	//		angle = Mathf.Acos(angle);
	//		angle = Mathf.Rad2Deg * angle;


	//		외적을 구해서 외적의 순서가
	//		spawnEnemy.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	//		BulletFireSpeed = 0;
	//	}
	//}

	//void RotationMissile()
	//{
	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > 0.5f)
	//	{
	//		Vector3 bulletPos = this.transform.position;
	//		Vector3 v3RotatedDirection = Vector3.zero;
	//		GameObject[] spawnEnemy = new GameObject[8];

	//		for (int i = 0; i < 8; i++)
	//		{
	//			spawnEnemy[i] = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;
	//			v3RotatedDirection = Quaternion.Euler(0f, 0f, 45f * i) * Vector3.up;
	//			spawnEnemy[i].transform.localRotation = Quaternion.AngleAxis(90 + 45 * i, Vector3.forward);
	//			spawnEnemy[i].GetComponent<Bullet>().BulletDir = v3RotatedDirection;
	//		}
	//		BulletFireSpeed = 0;
	//	}
	//}

	//void RoundMissile()
	//{
	//	roundBullet.transform.position = this.transform.position;
	//	roundBullet.transform.rotation = Quaternion.Euler(0, 0, (RotateTime++) * 1.5f);
	//}

	//void RotationOneMissile()
	//{
	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > 0.1f)
	//	{
	//		Vector3 bulletPos = Vector3.zero;
	//		Vector3 v3RotatedDirection = Vector3.zero;
	//		GameObject spawnEnemy = null;

	//		bulletPos = this.transform.position;

	//		spawnEnemy = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;

	//		v3RotatedDirection = Quaternion.Euler(0f, 0f, 22.5f * DirCount) * Vector3.up;
	//		spawnEnemy.transform.localRotation = Quaternion.AngleAxis(90 + 22.5f * DirCount++, Vector3.forward);
	//		spawnEnemy.GetComponent<Bullet>().BulletDir = v3RotatedDirection;//Vector3.up; 

	//		BulletFireSpeed = 0;
	//	}
	//}

	//미구현
	//void ChaserMissile()
	//{

	//	BulletFireSpeed += Time.deltaTime;
	//	if (BulletFireSpeed > 0.1f)
	//	{
	//		Vector3 bulletPos = this.transform.position;
	//		bulletPos.z = 1;

	//		GameObject spawnEnemy = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;

	//		float Radius = 22.5f;
	//		Quaternion v3Rotation = Quaternion.Euler(0f, 0f, Radius += 22.5f);  // 회전각 
	//		Vector3 v3Direction = Vector3.up; // 회전시킬 벡터(테스트용으로 world forward 썼음) 
	//		Vector3 v3RotatedDirection = v3Rotation * v3Direction;
	//		spawnEnemy.transform.right = v3RotatedDirection;
	//		spawnEnemy.GetComponent<Bullet>().BulletDir = Vector3.right;//Vector3.up; 

	//		BulletFireSpeed = 0;
	//	}
	//}
}
