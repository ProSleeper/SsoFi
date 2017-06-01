using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoSingleton<ResultManager>
{
	UIButton ToHome;
	UIButton ToStage;
	UIButton ReStart;

	UILabel BestScore;
	UILabel BestTime;
	UILabel CurrScore;
	UILabel CurrTime;

	void Start () 
	{
		ToHome = GameObject.Find("ToHomeButton").GetComponent<UIButton>();
		ToStage = GameObject.Find("ToStageButton").GetComponent<UIButton>();
		ReStart = GameObject.Find("ReStartButton").GetComponent<UIButton>();

		BestScore = GameObject.Find("BestResult").transform.FindChild("Score").GetComponent<UILabel>();
		BestTime = GameObject.Find("BestResult").transform.FindChild("Time").GetComponent<UILabel>();
		CurrScore = GameObject.Find("CurrentResult").transform.FindChild("Score").GetComponent<UILabel>();
		CurrTime = GameObject.Find("CurrentResult").transform.FindChild("Time").GetComponent<UILabel>();
		SetResult();
		SetButton();
	}


	void SetResult()
	{
		CurrScore.text = "Score : " + ScoreManager.Instance.Score.ToString();
		CurrTime.text = "Time : " + ScoreManager.Instance.Score.ToString();

	}

	void SetButton()
	{
		ToHome.onClick.Add(new EventDelegate(SetToHomeButton));
		ToStage.onClick.Add(new EventDelegate(SetToStageButton));
		ReStart.onClick.Add(new EventDelegate(SetReStartButton));
	}

	void SetToHomeButton()
	{
		SceneManager.LoadScene(0);
	}

	void SetToStageButton()
	{

	}

	void SetReStartButton()
	{
		SceneManager.LoadScene(1);
	}
}
