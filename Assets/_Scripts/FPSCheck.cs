using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCheck : MonoBehaviour 
{

	UILabel FPS;
	float CurTime = 0;
	int FPSCount = 0;

	void Start () 
	{
		FPS = this.GetComponent<UILabel>();
	}

	private void Update()
	{
		//프레임 체크
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
	}
}
