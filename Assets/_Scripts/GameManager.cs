using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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



	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		if (EnemyManager.Instance.Count > 10)
		{
			EnemyManager.Instance.RemoveEnemy();
		}
		
	}

	
}
