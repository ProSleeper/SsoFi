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
		playerDir = new Vector3(0, 1, 0);
	}

    // Update is called once per frame
    void Update()
    {
        playerDir = (player.transform.position - this.transform.position).normalized;
        this.transform.position += playerDir * chaseSpeed * Time.deltaTime;

		float angle = Vector3.Dot(playerDir, Vector3.up);

		Vector3 cross =  Vector3.Cross(Vector3.up, playerDir);
		float dosu = Mathf.Acos(angle);

		
		dosu = Mathf.Rad2Deg * dosu;

		//Debug.Log(cross);

		//외적을 구해서 외적의 순서가 
		if (Vec3Lenth(cross))
		{
			transform.localRotation = Quaternion.AngleAxis(Mathf.PI - dosu, Vector3.back);
		}
		else
		{
			transform.localRotation = Quaternion.AngleAxis(-dosu, Vector3.forward);
		}
	}

	bool Vec3Lenth(Vector3 v)
	{
		return (v.x + v.y + v.z) > 0.0f ? true : false;
	}
}
