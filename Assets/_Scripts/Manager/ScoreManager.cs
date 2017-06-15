using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//이 매니저는 삭제하고 게임매니저로 통합!
public class ScoreManager : MonoBehaviour
{
	private static ScoreManager _instance = null;

	public static ScoreManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("EnemyManager == null");
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
	}


	int BestScore;
	float BestTime;
	int CurScore;
	float CurTime;
	float PrevTime;
	string BestScoreKey = string.Empty;
	string BestTimeKey = string.Empty;

	UILabel ScoreText;


	// Use this for initialization
	void Start ()
	{
		CurScore = 0;
		CurTime = 0;
		PrevTime = 0;
		BestTime = 0;
		
		BestScoreKey = "BestScore";
		BestTimeKey = "BestTime";
		ScoreText = GameObject.Find("Score").GetComponentInChildren<UILabel>();
		if (ScoreText != null)
		{
			ScoreText.text = "Score: 0";
		}

	}

	public void AddScore(int score)
	{
		CurScore += score;
		ScoreText.text = "Score: " + CurScore.ToString();
	}

	public int GetCurScore()
	{
		return CurScore;
	}

	public float GetCurTime()
	{
		return CurTime;
	}

	public int GetBestScore()
	{
		BestScore = PlayerPrefs.GetInt(BestScoreKey);
		if (BestScore < CurScore)
		{
			PlayerPrefs.SetInt(BestScoreKey, CurScore);
			BestScore = CurScore;
		}
		return BestScore;
	}

	public float GetBestTime()
	{
		BestTime = PlayerPrefs.GetFloat(BestTimeKey);
		if (BestTime == 0)
		{
			BestTime = 99999;
		}

		if (BestTime > CurTime)
		{
			PlayerPrefs.SetFloat(BestTimeKey, CurTime);
			BestTime = CurTime;
		}
		return BestTime;
	}

	public float GetBestOverScore()
	{
		BestScore = PlayerPrefs.GetInt(BestScoreKey);
		return BestScore;
	}

	public float GetBestOverTime()
	{
		BestTime = PlayerPrefs.GetFloat(BestTimeKey);
		return BestTime;
	}

	public void SetCurTime()
	{
		CurTime = Time.time - PrevTime;
	}

	public void SetPrevTime()
	{
		PrevTime = Time.time;
	}
}
