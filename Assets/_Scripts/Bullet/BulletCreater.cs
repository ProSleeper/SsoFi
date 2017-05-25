using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BULLET_TYPE
{
	BT_BIG,
	BT_BULLET,
	BT_CHASE,
	BT_EIGHTDIR,
	BT_ONEROTATE,
	BT_ORBIT,
	BT_MAX
}

public class BulletCreater : MonoBehaviour
{

	GameObject[] BulletType;/* = new GameObject[(int)BULLET_TYPE.BT_MAX];*/

	GameObject CurGenerator = null;

	private void Start()
	{
		BulletType = Resources.LoadAll<GameObject>("Prefabs/Bullet/Generator");
		//BulletGenratorChange(BULLET_TYPE.BT_BULLET);
		BulletGeneratorChange(BULLET_TYPE.BT_BULLET);
	}

	public void BulletGeneratorChange(BULLET_TYPE bullet)
	{
		if (CurGenerator != null)
		{
			//들어와도 삭제가 안됨... 이게 뭥미..
			Destroy(CurGenerator);
			CurGenerator = null;
		}
		
		//intantiate를 할때 할당한 객체의 start는 아마도 해당 instantiate를 부른 스크립트가 끝나야 가는것 같다..
		//awake는 바로 들어감... 이거 왠만하면 그냥 start보다 awake쓰는게 나은듯..
		CurGenerator = Instantiate(BulletType[(int)bullet]);

		//뭔가 로컬포지션하고 월드포지션이 이상함.. 내일 확인 후 질문 ㄱㄱ
		CurGenerator.transform.parent = this.gameObject.transform;
	
		//제네레이터 로컬포지션				//0, 0, 0
		CurGenerator.transform.localPosition = Vector3.zero;

		//Debug.Log(CurGenerator.transform.childCount);
		//CurGenerator.transform.GetChild(0).gameObject.transform.localPosition = Vector3.zero;

	}
}
