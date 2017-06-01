using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rote : MonoBehaviour
{
	float angle;

	void Start ()
	{
		
	}

	private void Update()
	{
		this.transform.Rotate(Vector3.forward, angle = 45 * Time.deltaTime);
	}
}
