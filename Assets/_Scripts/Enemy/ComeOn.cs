using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeOn : MonoBehaviour 
{

	public GameObject Center;

	Vector3 MoveCenter;
	float rot = 0;

	void Start () 
	{
		this.transform.parent = Center.transform;
	}

	private void Update()
	{
		MoveCenter = Center.transform.position - this.transform.position;

		this.transform.position += MoveCenter.normalized * Time.deltaTime;

		if (Input.GetMouseButton(0))
		{
			this.transform.position += -(MoveCenter.normalized) * 1.25f * Time.deltaTime;
		}

		Center.transform.localRotation = Quaternion.Euler(0, 0, rot+=45 * Time.deltaTime);
	}
}
