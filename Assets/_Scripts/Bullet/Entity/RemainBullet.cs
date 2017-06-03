using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainBullet : DefaultBullet
{
    Vector3 s;
    Vector3 e;
    Vector3 ss;
    Vector3 ee;
    float dTime;
    float deadTime;


    // Use this for initialization
    void Start()
    {
        BulletDir = Vector3.zero - this.transform.position;
        if (Vector3.Distance(Vector3.zero, this.transform.position) < 1.0f)
        {
            BulletDir = Vector3.up;
        }
        s = this.transform.localScale;
        e = s * 1.2f;

        ss = s;
        ee = e;
    }


    void Update()
    {

        dTime += Time.deltaTime;
        this.transform.localScale = Vector3.Lerp(ss, ee, dTime / 1);
        if (dTime > 1)
        {
            Vector3 temp = s;
            s = e;
            e = temp;

            ss = s;
            ee = e;
            dTime = 0;
        }

        deadTime += Time.deltaTime;
        if (deadTime > 4.0f)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //이건 개별로 이름 비교하는거고
        //if (collision.gameObject.tag.Equals(TAGNAME.Enemy.ToString()) || collision.gameObject.tag.Equals(TAGNAME.EnemyBullet.ToString()))

        //이건 해당 문자열이 태그에 들어있는지 판단 ex) EnemyBullet 태그일때 Enemy 혹은 Bullet 중 하나만 가지고 판단이 가능함
        //문제는 나중에 태그가 더 많아졌을때 의도치 않은 충돌이 일어날 수 있음 
        if (CollTag.GetColl(this.tag, collision.tag))
        {
            SpawnParticle(this.transform.position);
        }
    }

    public override float BulletPower()
    {
        BulletDamage = 10;
        return BulletDamage;
    }



}
