using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCircleGenerator : Generator
{
    void Start()
    {
        Bullet = Resources.Load("Prefabs/Bullet/Entity/TripleCircleBullet") as GameObject;
    }

}
