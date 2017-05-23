using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	static ScoreManager instance = null;

	public static ScoreManager Instance
	{
		get
		{
			if (instance == null)
				Debug.LogError("ScoreManager == null");
			return instance;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	[HideInInspector]
	public int Score;

	
	// Use this for initialization
	void Start () {
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddScore()
	{
		Score += 1;
		//Debug.Log(Score);
	}
}
