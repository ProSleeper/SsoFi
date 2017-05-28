using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{
	protected float BulletSpeed;
    [HideInInspector]
	public Vector3 BulletDir = Vector3.zero;

	public float BulletAddForce
	{
		get
		{
			return BulletSpeed;
		}
		set
		{
			BulletSpeed = value;
		}
	}

	// Use this for initialization
	void Start()
    {
		BulletDir = Vector3.zero - this.transform.position;
		if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		{
			BulletDir = Vector3.up;
		}
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

		//정확히 반대 방향이라 오류가 나는듯 수정!
		cross = Vector3.Cross(Vector3.right, BulletDir);
		
		//외적값을 구하려는 두 벡터가 서로 평행하다면 외적값은 0이다.
		//이때 평행한 값이 나올 수 있는 경우는 서로 같은 방향이거나 180도 다른 방향이다.
		//같은 방향일때는 그 방향으로 이동하면 되는 것이라 상관없지만
		//다른 방향일때는 180도 회전을 해야하기 때문에 두 벡터값을 더해서 0이 나온다면 반대방향이고
		//그때 forward나 back 둘중 아무 값이나 주면 된다 왜 두가지 값이 모두 가능하냐면
		//어차피 180도를 돌기 때문에 축이 둘중 아무거나 상관이 없기 때문이다.
		if ((Vector3.right + BulletDir) == Vector3.zero)
		{
			cross = Vector3.back;
		}
		angle = Vector3.Dot(BulletDir, Vector3.right);
		angle = Mathf.Acos(angle);
		angle = Mathf.Rad2Deg * angle;

		//Debug.Log("이름 : " + this.gameObject.name + "\n외적 : " + cross + "\n회전각도 : " + angle + "\n이동방향 :" + BulletDir);
		

		this.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//이건 개별로 이름 비교하는거고
		//if (collision.gameObject.tag.Equals(TAGNAME.Enemy.ToString()) || collision.gameObject.tag.Equals(TAGNAME.EnemyBullet.ToString()))

		//이건 해당 문자열이 태그에 들어있는지 판단 ex) EnemyBullet 태그일때 Enemy 혹은 Bullet 중 하나만 가지고 판단이 가능함
		//문제는 나중에 태그가 더 많아졌을때 의도치 않은 충돌이 일어날 수 있음 
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			SpawnParticle(this.transform.position);
			Destroy(this.transform.gameObject);
		}
	}

	public virtual void SpawnParticle(Vector3 ExactPos)
	{
		GameObject temp = Instantiate(OnLoad.BulletParticle, ExactPos, Quaternion.identity);
		ParticleSystem.MainModule ps = temp.GetComponent<ParticleSystem>().main;
		ParticleSystem pe = temp.GetComponent<ParticleSystem>();
		float size = this.transform.localScale.x;
		ps.startSize = size;
		ps.startSpeed = size * 4;
		ps.startLifetime = (size * 4) / 10.0f;
		ps.maxParticles = (int)(size * 60.0f);
		ParticleSystem.Burst[] pb = new ParticleSystem.Burst[1];
		pb[0].minCount = (short)ps.maxParticles;
		pb[0].maxCount = (short)ps.maxParticles;
		pe.emission.SetBursts(pb);
	}
}
