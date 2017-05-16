using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public float    chaseSpeed;

    GameObject      player;
    Vector3         playerDir;


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");


    }

    // Update is called once per frame
    void Update()
    {
        playerDir = (player.transform.position - this.transform.position).normalized;
        this.transform.position += playerDir * chaseSpeed * Time.deltaTime;
        //float angle = Mathf.Acos(Vector2.Dot(new Vector2(playerDir.x, playerDir.y), new Vector2(this.transform.position.x, this.transform.position.y)));
        this.transform.up = playerDir;
        //편법으로 방향을 가르키게 만듬...

        //float dot = Vector3.Dot(playerDir, new Vector3(0, 1, 0));
        //float angle = Mathf.Acos(dot);
        //this.transform.Rotate(Vector3.back, angle);



    }
}
