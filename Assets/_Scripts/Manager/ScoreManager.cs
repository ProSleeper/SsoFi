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
	UILabel ScoreText;
	UILabel DeadCountText;

	// Use this for initialization
	void Start () {
		Score = 0;
		ScoreText = GameObject.Find("Score").GetComponentInChildren<UILabel>();
		ScoreText.text = "Score: 0";
	}

	public void AddScore()
	{
		Score += 5;
		ScoreText.text = "Score: " +  Score.ToString();
		Debug.Log(Score);
	}
}
