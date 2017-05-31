using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour 
{
	UIButton ThisButton;

	void Start () 
	{
		ThisButton = this.transform.GetComponent<UIButton>();
		ThisButton.onClick.Add(new EventDelegate(this, "OnClickStartButton"));
	}

	void OnClickStartButton()
	{
		SceneManager.LoadScene(1);
	}
}
