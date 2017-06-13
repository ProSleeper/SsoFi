using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleCircleBullet : DefaultBullet
{
    float RotValue;
    void Update()
    {
        EnemyChase();
        this.transform.rotation = Quaternion.AngleAxis(RotValue+=5, Vector3.back);
    }

    public override float BulletPower()
    {
        BulletDamage = 20;
        return BulletDamage;
    }
}
