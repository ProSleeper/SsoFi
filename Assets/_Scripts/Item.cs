using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public float rotSpeed;
	float Speed;

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Euler(0, 0, Speed += rotSpeed * Time.deltaTime);
	}
}
