using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPhaseBullet : DefaultBullet
{
    Transform GoalPlayer = null;
    Vector3 CurrentPos = Vector3.zero;
    Vector3 LastPos = Vector3.zero;

    float dTime = 0;
    float endTime = 0;

    void Start()
    {
        BulletDir = Vector3.zero - this.transform.position;
        if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
        {
            BulletDir = Vector3.up;
        }
        GoalPlayer = GameObject.Find("Player").transform;
        CurrentPos = this.transform.position;
        LastPos = this.transform.position + (BulletDir.normalized * 20);
    }

    void Update()
    {
        dTime += Time.deltaTime;
        endTime += Time.deltaTime;
        this.transform.position = Vector3.Lerp(CurrentPos, LastPos, dTime / 2);
        if (dTime > 2f)
        {
            CurrentPos = LastPos;
            LastPos = GoalPlayer.position;
            dTime = 0;
        }

        if (endTime > 4f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (CollTag.GetColl(this.tag, collision.tag))
		{
			Vector3 temp = collision.transform.position - this.transform.position;
			float radius = this.GetComponent<CircleCollider2D>().radius;

            SpawnParticle(this.transform.position + temp.normalized * radius);
		}
	}

	public override float BulletPower()
	{
		BulletDamage = 30;
		return BulletDamage;
	}
}
