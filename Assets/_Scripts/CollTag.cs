using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TAG_NAME
{
	Untagged,
	Player,
	PlayerBullet,
	Enemy,
	EnemyBullet,
	Item,
	Max
}

public static class CollTag 
{

	static bool[,] collTag;
	static Dictionary<string, TAG_NAME> DicTagName = new Dictionary<string, TAG_NAME>();

	public static void SetColl()
	{
		collTag = new bool[(int)TAG_NAME.Max, (int)TAG_NAME.Max];

		collTag[(int)TAG_NAME.Player, (int)TAG_NAME.Enemy] = true;
		collTag[(int)TAG_NAME.Enemy, (int)TAG_NAME.Player] = true;

		collTag[(int)TAG_NAME.Player, (int)TAG_NAME.EnemyBullet] = true;
		collTag[(int)TAG_NAME.EnemyBullet, (int)TAG_NAME.Player] = true;

		collTag[(int)TAG_NAME.Item, (int)TAG_NAME.Player] = true;

		collTag[(int)TAG_NAME.PlayerBullet, (int)TAG_NAME.Enemy] = true;
		collTag[(int)TAG_NAME.Enemy, (int)TAG_NAME.PlayerBullet] = true;

		DicTagName.Clear();

		for (int i = 0; i < (int)TAG_NAME.Max; i++)
		{
			DicTagName.Add(((TAG_NAME)i).ToString(), (TAG_NAME)i);
		}
	}

	public static bool GetColl(string thisObject, string collObject)
	{
		TAG_NAME thisNum;
		TAG_NAME collNum;
		DicTagName.TryGetValue(thisObject, out thisNum);
		DicTagName.TryGetValue(collObject, out collNum);

		return collTag[(int)thisNum, (int)collNum];
	}
}
