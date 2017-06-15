using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartBullet : DefaultBullet
{
    Vector3 SecondDir;
    float sc = 20;
    int BulletSideDir = 1;
    float rotateValue;

    public int BULLETSIDEDIR
    {
        get
        {
            return BulletSideDir;
        }
        set
        {
            BulletSideDir = value;
        }
    }
    void Start()
    {
        BulletDir = Vector3.zero - this.transform.position;
        if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
        {
            BulletDir = Vector3.up;
        }
    }

    void Update()
    {
        EnemyChase();

        SecondDir = Quaternion.AngleAxis(90, Vector3.back) * BulletDir;
        this.gameObject.transform.position += SecondDir * BulletSideDir * Time.deltaTime * (sc -= 1f);
        this.gameObject.transform.rotation = Quaternion.AngleAxis(rotateValue += 360 * 2 * Time.deltaTime, Vector3.back * BulletSideDir);
    }

    public override float BulletPower()
    {
        BulletDamage = 30;
        return BulletDamage;
    }
}
