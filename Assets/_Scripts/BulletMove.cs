using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	public float BulletSpeed = 3;
	public Vector3 BulletDir = new Vector3(0, 1, 0);

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
