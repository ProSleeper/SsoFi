using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagInit : MonoBehaviour
{
	void Start ()
	{
		this.gameObject.tag = RecursiveTag(this.gameObject);
	}

	//재귀함수로 최상위 오브젝트의 태그로 하위 모든 태그를 변경
	string RecursiveTag(GameObject own)
	{
		string tag = string.Empty;
		if (own.transform.parent != null)
		{
			tag = RecursiveTag(own.transform.parent.gameObject);
			own.tag = tag;
		}
		else
		{
			tag = own.gameObject.tag;
		}
		return tag;
	}
}
