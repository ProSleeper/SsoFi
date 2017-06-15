using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleRote : MonoBehaviour
{
	float angle;

	void Start ()
	{
		
	}

	private void Update()
	{
		this.transform.Rotate(Vector3.forward, angle = 360 * Time.deltaTime);
	}
}
