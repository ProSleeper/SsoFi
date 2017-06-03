using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorAnimation : MonoBehaviour
{
	GameObject Meteor;
	GameObject Shadow;
	GameObject Crash;


	Vector3 MeteorPosition;
	float dTime;

	private void Awake()
	{
		Meteor = this.transform.FindChild("Meteor").gameObject;
		Shadow = this.transform.FindChild("Shadow").gameObject;
		Crash = this.transform.FindChild("Crash").gameObject;

		Crash.SetActive(false);
	}

	void Start ()
	{
		MeteorPosition = Meteor.transform.position;
	}

	private void Update()
	{
		dTime += Time.deltaTime;
		Meteor.transform.localPosition = Vector3.Lerp(MeteorPosition, Vector3.zero, dTime / 1.5f);
		Meteor.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 3, dTime / 1.5f);

		if (dTime > 1.5f)
		{
			Meteor.SetActive(false);
			Shadow.SetActive(false);
			Crash.SetActive(true);
		}
	}
}

//메테오 효과
//Vector3 s;
//Vector3 e;
//float dTime;
//Vector3 ss;
//Vector3 ee;
//public GameObject eff;
//public GameObject efg;

//void Start()
//{
//	s = this.transform.position;
//	e = Vector3.zero;
//	ee = this.transform.localScale;
//	ss = Vector3.one;
//	eff.SetActive(false);
//}


//private void Update()
//{
//	dTime += Time.deltaTime;
//	this.transform.position = Vector3.Lerp(s, e, dTime / 2);
//	this.transform.localScale = Vector3.Lerp(ss, Vector3.one * 3, dTime / 2);

//	if (dTime > 2.0f)
//	{
//		eff.transform.localScale = new Vector3(4, 4, 4);
//		eff.SetActive(true);
//		this.gameObject.SetActive(false);
//		efg.SetActive(false);
//	}
//}

//크래쉬 효과 코드
//float dTime;
//public AnimationCurve curve;

//void Start()
//{

//}

//private void Update()
//{
//	dTime += Time.deltaTime;
//	Debug.Log(curve.Evaluate(dTime));
//	this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, curve.Evaluate(dTime));

//	if (dTime > 1.0f)
//	{

//	}
//}