using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//이 매니저는 삭제하고 게임매니저로 통합!
public class ScoreManager : MonoSingleton<ScoreManager>
{
	[HideInInspector]
	public int Score;
	UILabel ScoreText;
	UILabel DeadCountText;

	// Use this for initialization
	void Start ()
	{
		Score = 0;
		ScoreText = GameObject.Find("Score").GetComponentInChildren<UILabel>();
		if (ScoreText != null)
		{
			ScoreText.text = "Score: 0";
		}
	}

	public void AddScore()
	{
		Score += 5;
		ScoreText.text = "Score: " +  Score.ToString();
		Debug.Log(Score);
	}
}
