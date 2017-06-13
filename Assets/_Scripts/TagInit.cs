using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//최상위 오브젝트의 태그를 검색해서 해당 하위 오브젝트(하위로 내려올땐 계층당 하나만 됨.) 태그를 최상위 태그로 바꿔줌 (재귀)
public class TagInit : MonoBehaviour
{
	void Start ()
	{
		this.gameObject.tag = RecursiveOwnTag(this.gameObject);
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

    string RecursiveOwnTag(GameObject own)
    {
        string tag = string.Empty;
        if (own.transform.parent != null)
        {
            tag = RecursiveOwnTag(own.transform.parent.gameObject);
        }
        else
        {
            tag = own.gameObject.tag;
        }
        return tag;
    }
}
