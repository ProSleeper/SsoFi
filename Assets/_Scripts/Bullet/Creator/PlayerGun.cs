using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//뭐 이런 방식으로도 가능하다는걸 알고 나중에 혹시라도 바꿀 수 있음...
public class PlayerGun : MonoBehaviour
{
	Generator[] Gun = new Generator[(int)BULLET_TYPE.BT_MAX];
	string BulletTag = string.Empty;

	private void Start()
	{
		this.tag = TAG_NAME.PlayerBullet.ToString();
		Gun[(int)BULLET_TYPE.BT_BIG] = this.gameObject.AddComponent<BigGenerator>();
		Gun[(int)BULLET_TYPE.BT_BULLET] = this.gameObject.AddComponent<BulletGenerator>();
		Gun[(int)BULLET_TYPE.BT_CHASE] = this.gameObject.AddComponent<ChaserGenerator>();
		Gun[(int)BULLET_TYPE.BT_EIGHTDIR] = this.gameObject.AddComponent<EightGenerator>();
		Gun[(int)BULLET_TYPE.BT_ONEROTATE] = this.gameObject.AddComponent<OneRotateGenerator>();
		Gun[(int)BULLET_TYPE.BT_ORBIT] = this.gameObject.AddComponent<OrbitGenerator>();
		Gun[(int)BULLET_TYPE.BT_SECTOR] = this.gameObject.AddComponent<SectorGenerator>();


		Gun[(int)BULLET_TYPE.BT_BIG].BulletSetting(new Vector3(1f, 1f, 1f), 20, 2f);
		Gun[(int)BULLET_TYPE.BT_BULLET].BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 0.2f);
		Gun[(int)BULLET_TYPE.BT_CHASE].BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 10, 0.25f);
		Gun[(int)BULLET_TYPE.BT_EIGHTDIR].BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 1.0f, 45f);
		Gun[(int)BULLET_TYPE.BT_ONEROTATE].BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 30, 0.1f, 22.5f);
		Gun[(int)BULLET_TYPE.BT_ORBIT].BulletSetting(new Vector3(1f, 1f, 1f), 0, 0, 160f, 4.5f);
		Gun[(int)BULLET_TYPE.BT_SECTOR].BulletSetting(new Vector3(0.5f, 0.5f, 0.5f), 35, 1.0f, 5f);


		//(Gun[(int)BULLET_TYPE.BT_ORBIT] as OrbitGenerator).Orbit.SetActive(false);

		//for (int i = 0; i < (int)BULLET_TYPE.BT_MAX; i++)
		//{
		//	BulletEntity[i] = Instantiate(BulletType[i]);
		//	BulletEntity[i].transform.parent = this.gameObject.transform;
		//	BulletEntity[i].tag = TAG_NAME.PlayerBullet.ToString();
		//}

		BulletGeneratorChange(BULLET_TYPE.BT_BULLET);
	}

	public void BulletGeneratorChange(BULLET_TYPE bullet)
	{
		for (int i = 0; i < (int)BULLET_TYPE.BT_MAX; i++)
		{
			Gun[i].enabled = false;
		}

		Gun[(int)bullet].enabled =true;
	}
}
