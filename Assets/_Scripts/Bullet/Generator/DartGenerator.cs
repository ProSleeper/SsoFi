using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartGenerator : Generator
{
    void Start()
    {
        Bullet = Resources.Load("Prefabs/Bullet/Entity/DartBullet") as GameObject;
    }

    public override void FireBullet()
    {
        GameObject temp = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        temp.GetComponent<DefaultBullet>().BULLETSPEED = MoveSpeed;
        temp.transform.localScale = BulletSize;
        temp.tag = this.tag;

        temp = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        temp.GetComponent<DartBullet>().BULLETSIDEDIR = -1;
        temp.GetComponent<DefaultBullet>().BULLETSPEED = MoveSpeed;
        temp.transform.localScale = BulletSize;
        temp.tag = this.tag;
    }
}
