using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlayerGenerator : Generator
{
    void Start()
    {
        Bullet = Resources.Load("Prefabs/Bullet/Entity/GrowPlayerBullet") as GameObject;
    }
}
