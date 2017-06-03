using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangleBullet : DefaultBullet
{

    public override void EnemyChase()
    {
        BulletDir.Normalize();
        this.transform.position += BulletDir * BulletSpeed * Time.deltaTime;
        Vector3 cross = Vector3.zero;
        float angle = 0;

        //정확히 반대 방향이라 오류가 나는듯 수정!
        cross = Vector3.Cross(Vector3.up, BulletDir);

        //외적값을 구하려는 두 벡터가 서로 평행하다면 외적값은 0이다.
        //이때 평행한 값이 나올 수 있는 경우는 서로 같은 방향이거나 180도 다른 방향이다.
        //같은 방향일때는 그 방향으로 이동하면 되는 것이라 상관없지만
        //다른 방향일때는 180도 회전을 해야하기 때문에 두 벡터값을 더해서 0이 나온다면 반대방향이고
        //그때 forward나 back 둘중 아무 값이나 주면 된다 왜 두가지 값이 모두 가능하냐면
        //어차피 180도를 돌기 때문에 축이 둘중 아무거나 상관이 없기 때문이다.


        if ((Vector3.right + BulletDir) == Vector3.zero)
        {
            cross = Vector3.back;
        }
        angle = Vector3.Dot(BulletDir, Vector3.up);
        angle = Mathf.Acos(angle);
        angle = Mathf.Rad2Deg * angle;

        //Debug.Log("이름 : " + this.gameObject.name + "\n외적 : " + cross + "\n회전각도 : " + angle + "\n이동방향 :" + BulletDir);


        this.transform.localRotation = Quaternion.AngleAxis(angle, cross.normalized);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CollTag.GetColl(this.tag, collision.tag))
        {

            Vector3 distance = collision.transform.position - this.transform.position;
            float aa = collision.transform.GetComponent<CircleCollider2D>().radius * collision.transform.localScale.x;
            Vector3 reverseDistance = -(distance.normalized * aa);
            SpawnParticle(this.transform.position + distance + reverseDistance);
            Debug.Log("직사각형충돌");
        }
    }

    public override float BulletPower()
    {
        BulletDamage = 25;
        return BulletDamage;
    }

}