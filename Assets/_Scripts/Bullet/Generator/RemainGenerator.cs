using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainGenerator : Generator
{
    void Start()
    {
        Bullet = Resources.Load("Prefabs/Bullet/Entity/RemainBullet") as GameObject;
    }
}

