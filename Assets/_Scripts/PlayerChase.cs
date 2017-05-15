using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : MonoBehaviour {

    public GameObject player;
    Vector3 playerDir;
    public float chaseSpeed;

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        playerDir = (player.transform.position - this.transform.position).normalized;
        this.transform.position += playerDir * chaseSpeed * Time.deltaTime;

    }
}
