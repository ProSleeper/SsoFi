using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum STAGE_PHASE
{
	Ready,
	Normal,
	Boss,
	Max
}

public class GameManager : MonoBehaviour
{
	private static GameManager _instance = null;

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("cSingleton == null");
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
	}

	public Text FPS;
	float CurTime = 0;
	int FPSCount = 0;
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		CurTime += Time.deltaTime;
		if (CurTime > 1.0f)
		{
			FPS.text = "FPS : " + FPSCount.ToString();
			FPSCount = 0;
			CurTime = 0;
			
		}
		else
		{
			FPSCount++;
		}

		//if (EnemyManager.Instance.Count > 10)
		//{
		//	EnemyManager.Instance.RemoveAllEnemy();
		//}	
	}
}
