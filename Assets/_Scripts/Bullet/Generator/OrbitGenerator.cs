using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitGenerator : BulletGenerator
{
	GameObject Orbit;

	// Use this for initialization
	void Awake () {
		//MaxFireSpeed = 0.0f;
		RotateDegree = 160f;
		Bullet = Resources.Load("Prefabs/Bullet/OrbitBullet") as GameObject;
		Orbit = Instantiate(Bullet);
		Orbit.transform.parent = this.transform;
	}

	public override void FireMissile()
	{
		//플레이어 -> 제너레이터 -> 랩핑 -> 실제 미사일 계층으로 되어있는데 포지션 오류가 났던 이유는
		//위치 초기화를 하려면 이것들을 순차적으로 초기화해줘야 제대로 초기화가 된다.
		//만약 실제 미사일부터 초기화를 하고 그 후에 제너레이터나 랩핑 오브젝트가 초기화를 진행하면 내 좌표는 다시 어긋나게 된다. 
		//Orbit.transform.localPosition = Vector3.zero;
		this.transform.rotation = Quaternion.Euler(0, 0, RoundSpeed += 160f * Time.deltaTime);
	}
}
