using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PARTICLE
{
	EnemyBullet,
	EnemyDeathSquare,
	EnemyDeathTriangle,
	EnemyThinBullet,
	PlayerBullet,
	PlayerThinBullet,
	BossBullet,
	BossThinBullet,
	Max
}

public class ParticleManager : MonoBehaviour 
{
	static ParticleManager instance = null;

	public static ParticleManager Instance
	{
		get
		{
			if (instance == null)
			{
				Debug.LogError("ParticleManager 없음");
			}
			return instance;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		
	}

	public void ParticleCreate(PARTICLE particle, Vector3 position)
	{
		GameObject newParticle = Instantiate(LoadData.ArrayParticle[(int)particle], position, Quaternion.identity);
	}
}
