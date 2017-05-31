using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinTimeBullet : DefaultBullet
{
	[HideInInspector]
	public float BombTime;
	public float BombScope;

	void Start()
	{
		BulletDir = Vector3.zero - this.transform.position;
		if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
		{
			BulletDir = Vector3.up;
		}
		Invoke("SuicideBullet", BombTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (OnLoad.GetColl(this.tag, collision.tag))
		{
			SuicideBullet();
		}
	}

	void SuicideBullet()
	{
		GameObject temp = Instantiate(OnLoad.ThinSubBullet, this.transform.position, Quaternion.identity);
		temp.GetComponent<SuicideBomb>().EndRadius = BombScope;
		temp.tag = this.tag;
		SpawnParticle(this.transform.position);
		Destroy(this.transform.gameObject);
	}

	public override void SpawnParticle(Vector3 ExactPos)
	{
		GameObject particle = Instantiate(OnLoad.ThinBulletParticle, ExactPos, Quaternion.identity);
		ParticleSetting(particle);
	}

	public override void ParticleSetting(GameObject particle)
	{
		ParticleSystem.MainModule ps = particle.GetComponent<ParticleSystem>().main;
		ParticleSystem pe = particle.GetComponent<ParticleSystem>();
		ps.startSpeed = BombScope;
		ps.maxParticles = (int)BombScope * 25;
		ParticleSystem.Burst[] pb = new ParticleSystem.Burst[1];
		pb[0].minCount = (short)ps.maxParticles;
		pb[0].maxCount = (short)ps.maxParticles;
		pe.emission.SetBursts(pb);
	}


}
