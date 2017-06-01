using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorTest : MonoBehaviour
{

	Vector3 s;
	Vector3 e;
	float dTime;
	Vector3 ss;
	Vector3 ee;
	public GameObject eff;

	void Start ()
	{
		s = this.transform.position;
		e = Vector3.zero;
		ee = this.transform.localScale;
		ss = Vector3.zero;
	}


	private void Update()
	{
		dTime += Time.deltaTime;
		this.transform.position = Vector3.Lerp(s, e, dTime/2);
		this.transform.localScale = Vector3.Lerp(ss, Vector3.one * 2, dTime / 2);

		if (dTime > 2.0f)
		{
			eff.transform.localScale = new Vector3(2, 2, 2);
			eff.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
