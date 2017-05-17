using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	public float BulletSpeed;
	public Vector3 BulletDir;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(BulletDir * BulletSpeed * Time.deltaTime);	
	}
}
