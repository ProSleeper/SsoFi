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
	BT_FASTTHIN,
	BT_LINE,
	BT_METEOR,
	BT_ONEROTATE,
	BT_ORBIT,
	BT_RECTANGLE,
    BT_REMAIN,
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

		BulletEntity[(int)BULLET_TYPE.BT_ONEROTATE].SetActive(true);
		BulletEntity[(int)BULLET_TYPE.BT_BIG].SetActive(true);
		//BulletEntity[(int)BULLET_TYPE.BT_RECTANGLE].SetActive(true);
		//BulletEntity[(int)BULLET_TYPE.BT_LINE].SetActive(true);
	}
	
	//base 보스세팅
	public virtual void GeneratorSetting()
	{
        //제네레이터들이 결국 기본 제네레이터를 상속받은 상태이기 때문에 나중에 json으로 파싱한다면
        //반복문으로 돌면서 Generator에서의 BulletSetting 세팅해주면 됨. 왜냐면 BulletSetting이 가상함수이기 때문에
        //지금은 어차피 값들을 다 일일히 세팅해줘서 반복문에서 도는게 의미가 없음
		BulletEntity[(int)BULLET_TYPE.BT_BIG].GetComponent<BigGenerator>().BulletSetting(new Vector3(2f, 2f, 2f), 40, 1.5f);
		BulletEntity[(int)BULLET_TYPE.BT_BULLET].GetComponent<BulletGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 30, 0.2f);
		BulletEntity[(int)BULLET_TYPE.BT_CHASE].GetComponent<ChaserGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 10, 0.25f);
		BulletEntity[(int)BULLET_TYPE.BT_EIGHTDIR].GetComponent<EightGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 30, 1.0f, 45f);
		BulletEntity[(int)BULLET_TYPE.BT_ONEROTATE].GetComponent<OneRotateGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 25, 0.0f, 10.5f);
		BulletEntity[(int)BULLET_TYPE.BT_ORBIT].GetComponent<OrbitGenerator>().BulletSetting(new Vector3(2f, 2f, 2f), 0, 0, 160f, 3.5f);
		BulletEntity[(int)BULLET_TYPE.BT_SECTOR].GetComponent<SectorGenerator>().BulletSetting(new Vector3(1.2f, 1.2f, 1.2f), 35, 1.0f, 5f);
		BulletEntity[(int)BULLET_TYPE.BT_THINTIME].GetComponent<ThinTimeGenerator>().BulletSetting(new Vector3(1.0f, 1.0f, 1.0f), 35, 1f, 1.0f, 4);
		BulletEntity[(int)BULLET_TYPE.BT_LINE].GetComponent<LineGenerator>().BulletSetting(new Vector3(4f, 1f, 1f), 0, 0, 200f);
		BulletEntity[(int)BULLET_TYPE.BT_RECTANGLE].GetComponent<RectangleGenerator>().BulletSetting(new Vector3(9f, 7f, 1f), 25, 1.5f);
		BulletEntity[(int)BULLET_TYPE.BT_FASTTHIN].GetComponent<FastThinGenerator>().BulletSetting(new Vector3(0.3f, 0.3f, 1f), 45, 0.01f);
        BulletEntity[(int)BULLET_TYPE.BT_REMAIN].GetComponent<RemainGenerator>().BulletSetting(new Vector3(0.3f, 0.3f, 0.5f), 40, 0.1f);
		BulletEntity[(int)BULLET_TYPE.BT_METEOR].GetComponent<MeteorGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 0, 3f);


		BulletGeneratorChange(BULLET_TYPE.BT_FASTTHIN);
	}
}
