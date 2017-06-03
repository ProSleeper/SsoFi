using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGenerator : OneRotateGenerator
{
	[HideInInspector]
	public GameObject Orbit;

	float IntervalFromCenter;
	// Use this for initialization
	void Awake () {
		//MaxFireSpeed = 0.0f;
		Bullet = Resources.Load("Prefabs/Bullet/Entity/OrbitBullet") as GameObject;
		Orbit = Instantiate(Bullet);
		Orbit.transform.parent = this.transform;
	}
	private void Start()
	{
		Orbit.transform.localScale = BulletSize;
		Orbit.transform.GetChild(0).transform.localPosition = new Vector3(IntervalFromCenter, 0, 0);
	}

	public override void FireBullet()
	{
		//플레이어 -> 제너레이터 -> 랩핑 -> 실제 미사일 계층으로 되어있는데 포지션 오류가 났던 이유는
		//위치 초기화를 하려면 이것들을 순차적으로 초기화해줘야 제대로 초기화가 된다.
		//만약 실제 미사일부터 초기화를 하고 그 후에 제너레이터나 랩핑 오브젝트가 초기화를 진행하면 내 좌표는 다시 어긋나게 된다. 
		//Orbit.transform.localPosition = Vector3.zero;
		Orbit.transform.rotation = Quaternion.Euler(0, 0, CurDegree += AugmentDegree * Time.deltaTime);
		Orbit.transform.GetChild(0).transform.tag = this.tag;
	}

	public override void BulletSetting(Vector3 bulletSize, float moveSpeed, float fireSpeed, float value1, float value2)
	{
		BulletSetting(bulletSize, moveSpeed, fireSpeed, value1);
		IntervalFromCenter = value2;
	}
}
