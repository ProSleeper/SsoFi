using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BULLET_TYPE
{
	BT_BIG,
	BT_BULLET,
	BT_CHASE,
	BT_EIGHTDIR,
	BT_LINE,
	BT_ONEROTATE,
	BT_ORBIT,
	BT_SECTOR,
	BT_THINTIME,
	BT_MAX
}

//베이스는 보스 세팅으로 되어 있음
public class BulletCreater : MonoBehaviour
{
	protected GameObject[] BulletType;
	protected GameObject[] BulletEntity = new GameObject[(int)BULLET_TYPE.BT_MAX];

	private void Start()
	{
		BulletType = Resources.LoadAll<GameObject>("Prefabs/Bullet/Generator");
		
		for (int i = 0; i < (int)BULLET_TYPE.BT_MAX; i++)
		{
			BulletEntity[i] = Instantiate(BulletType[i]);
			BulletEntity[i].transform.parent = this.gameObject.transform;
			BulletEntity[i].transform.localPosition = Vector3.zero;
			BulletEntity[i].tag = TagSetting();
		}

		GeneratorSetting();
	}

	public virtual string TagSetting()
	{
		return TAG_NAME.EnemyBullet.ToString();
	}

	public virtual void BulletGeneratorChange(BULLET_TYPE bullet)
	{
		for (int i = 0; i < (int)BULLET_TYPE.BT_MAX; i++)
		{
			BulletEntity[i].SetActive(false);
		}

		//BulletEntity[(int)BULLET_TYPE.BT_EIGHTDIR].SetActive(true);
		//BulletEntity[(int)BULLET_TYPE.BT_ONEROTATE].SetActive(true);
		BulletEntity[(int)BULLET_TYPE.BT_THINTIME].SetActive(true);
		BulletEntity[(int)BULLET_TYPE.BT_LINE].SetActive(true);

	}
	
	//base 보스세팅
	public virtual void GeneratorSetting()
	{
		BulletEntity[(int)BULLET_TYPE.BT_BIG].GetComponent<BigGenerator>().BulletSetting(new Vector3(2f, 2f, 2f), 40, 1.5f);
		BulletEntity[(int)BULLET_TYPE.BT_BULLET].GetComponent<BulletGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 30, 0.2f);
		BulletEntity[(int)BULLET_TYPE.BT_CHASE].GetComponent<ChaserGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 10, 0.25f);
		BulletEntity[(int)BULLET_TYPE.BT_EIGHTDIR].GetComponent<EightGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 30, 1.0f, 45f);
		BulletEntity[(int)BULLET_TYPE.BT_ONEROTATE].GetComponent<OneRotateGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 25, 0.0f, 10.5f);
		BulletEntity[(int)BULLET_TYPE.BT_ORBIT].GetComponent<OrbitGenerator>().BulletSetting(new Vector3(2f, 2f, 2f), 0, 0, 160f, 3.5f);
		BulletEntity[(int)BULLET_TYPE.BT_SECTOR].GetComponent<SectorGenerator>().BulletSetting(new Vector3(1.2f, 1.2f, 1.2f), 35, 1.0f, 5f);
		BulletEntity[(int)BULLET_TYPE.BT_THINTIME].GetComponent<ThinTimeGenerator>().BulletSetting(new Vector3(1.0f, 1.0f, 1.0f), 35, 1f, 1.2f, 4);
		BulletEntity[(int)BULLET_TYPE.BT_LINE].GetComponent<LineGenerator>().BulletSetting(new Vector3(4f, 1f, 1f), 0, 0, 360f);

		BulletGeneratorChange(BULLET_TYPE.BT_THINTIME);
	}
}
