using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour
{
	public float BulletSpeed;
	[HideInInspector]
	public Vector3 BulletDir = Vector3.zero;


	private void Awake()
	{
		this.gameObject.tag = TAG_NAME.PlayerBullet.ToString();
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


		cross = Vector3.Cross(Vector3.right, BulletDir);
		angle = Vector3.Dot(BulletDir, Vector3.right);
		angle = Mathf.Acos(angle);
		angle = Mathf.Rad2Deg * angle;

		this.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//이건 개별로 이름 비교하는거고
		//if (collision.gameObject.tag.Equals(TAGNAME.Enemy.ToString()) || collision.gameObject.tag.Equals(TAGNAME.EnemyBullet.ToString()))

		//이건 해당 문자열이 태그에 들어있는지 판단 ex) EnemyBullet 태그일때 Enemy 혹은 Bullet 중 하나만 가지고 판단이 가능함
		//문제는 나중에 태그가 더 많아졌을때 의도치 않은 충돌이 일어날 수 있음 
		if (collision.gameObject.tag.Contains(TAG_NAME.Enemy.ToString()))
		{
			Destroy(this.transform.parent.gameObject);
		}
	}
}
