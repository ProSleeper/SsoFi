using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
	private static ResultManager _instance = null;

	public static ResultManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("EnemyManager == null");
			return _instance;
		}
	}

	GameObject ResultPanel;
	GameObject Best;
	GameObject Current;

	UIButton ToHome;
	UIButton ToStage;
	UIButton ReStart;

	UILabel BestScore;
	UILabel BestTime;
	UILabel CurrScore;
	UILabel CurrTime;

	private void Awake()
	{
		_instance = this;
		ResultPanel = GameObject.Find("Camera").transform.FindChild("ResultPanel").gameObject;
		Best = ResultPanel.transform.FindChild("BestResult").gameObject;
		Current = ResultPanel.transform.FindChild("CurrentResult").gameObject;

		ToHome = ResultPanel.transform.FindChild("ToHomeButton").GetComponent<UIButton>();
		ToStage = ResultPanel.transform.FindChild("ToStageButton").GetComponent<UIButton>();
		ReStart = ResultPanel.transform.FindChild("ReStartButton").GetComponent<UIButton>();

		BestScore = Best.transform.FindChild("Score").GetComponent<UILabel>();
		BestTime = Best.transform.FindChild("Time").GetComponent<UILabel>();
		CurrScore = Current.transform.FindChild("Score").GetComponent<UILabel>();
		CurrTime = Current.transform.FindChild("Time").GetComponent<UILabel>();
		Debug.Log("리절트 매니저 어웨이크");
	}

	void Start ()
	{
		SetButton();
	}


	public void ClearResult()
	{
		ResultPanel.SetActive(true);

		BestScore.text = "Score : " + ScoreManager.Instance.GetBestScore().ToString();

		float bt = ScoreManager.Instance.GetBestTime();

		BestTime.text = "Time : " + Math.Round(bt, 1).ToString();
		CurrScore.text = "Score : " + ScoreManager.Instance.GetCurScore().ToString();

		float ct = ScoreManager.Instance.GetCurTime();
		CurrTime.text = "Time : " + Math.Round(ct, 1).ToString();
	}

	public void OverResult()
	{
		ResultPanel.SetActive(true);

		BestScore.text = "Score : " + ScoreManager.Instance.GetBestOverScore().ToString();
		float bt = ScoreManager.Instance.GetBestOverTime();
		BestTime.text = "Time : " + Math.Round(bt, 1).ToString();
		CurrScore.text = "Score : " + 0;
		CurrTime.text = "Time : " + 0;
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
