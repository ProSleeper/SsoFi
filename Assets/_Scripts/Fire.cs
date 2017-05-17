using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {


	Vector3 NextTrans;
	Vector3 PrevTrans;
	Vector3 BulletDir = Vector3.up;
	float BulletFireSpeed;
	GameObject bullet;

	// Use this for initialization
	void Start () {
		bullet = Resources.Load("Prefabs/Bullet") as GameObject;
	}

	// Update is called once per frame
	void Update() {

		if (Input.GetMouseButton(0))
		{
			BulletDir = Vector3.zero - this.transform.position;
			BulletDir.Normalize();
			if (BulletDir == Vector3.zero)
			{
				BulletDir = Vector3.up;
			}
		}

		//if (Input.GetKeyDown(KeyCode.Space))
		BulletFireSpeed += Time.deltaTime;
		if(BulletFireSpeed > 0.2f)
		{
			
			GameObject spawnEnemy = Instantiate(bullet, this.transform.position , Quaternion.identity) as GameObject;
			spawnEnemy.GetComponent<BulletMove>().BulletDir = BulletDir;
			spawnEnemy.name = "Bullet";
			Debug.Log(BulletDir);
			BulletFireSpeed = 0;
		}
		
		PrevTrans = this.transform.position;
	}
}
