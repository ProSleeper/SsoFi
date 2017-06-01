using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCreator : BulletCreater
{
	public override string TagSetting()
	{
		return TAG_NAME.PlayerBullet.ToString();
	}
	
	public override void BulletGeneratorChange(BULLET_TYPE bullet)
	{
		for (int i = 0; i < (int)BULLET_TYPE.BT_MAX; i++)
		{
			BulletEntity[i].SetActive(false);
		}

		BulletEntity[(int)bullet].SetActive(true);
	}

	public override void GeneratorSetting()
	{
		BulletEntity[(int)BULLET_TYPE.BT_BIG].GetComponent<BigGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 20, 2f);
		BulletEntity[(int)BULLET_TYPE.BT_BULLET].GetComponent<BulletGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 0.2f);
		BulletEntity[(int)BULLET_TYPE.BT_CHASE].GetComponent<ChaserGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 10, 0.25f);
		BulletEntity[(int)BULLET_TYPE.BT_EIGHTDIR].GetComponent<EightGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 1.0f, 45f);
		BulletEntity[(int)BULLET_TYPE.BT_ONEROTATE].GetComponent<OneRotateGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 0.1f, 22.5f);
		BulletEntity[(int)BULLET_TYPE.BT_ORBIT].GetComponent<OrbitGenerator>().BulletSetting(new Vector3(1f, 1f, 1f), 0, 0, 160f, 2.5f);
		BulletEntity[(int)BULLET_TYPE.BT_SECTOR].GetComponent<SectorGenerator>().BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 35, 1.0f, 5f);
		BulletEntity[(int)BULLET_TYPE.BT_THINTIME].GetComponent<ThinTimeGenerator>().BulletSetting(new Vector3(0.3f, 0.3f, 0.3f), 8, 1f, 0.7f, 3);
		BulletEntity[(int)BULLET_TYPE.BT_LINE].GetComponent<LineGenerator>().BulletSetting(new Vector3(0.6f, 1f, 1f), 0, 0, 100f);
		BulletEntity[(int)BULLET_TYPE.BT_RECTANGLE].GetComponent<RectangleGenerator>().BulletSetting(new Vector3(5f, 4f, 1f), 8, 5.0f);

		BulletGeneratorChange(BULLET_TYPE.BT_RECTANGLE);
	}
}
