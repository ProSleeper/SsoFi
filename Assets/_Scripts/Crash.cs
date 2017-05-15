using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("플레이어 충돌!");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
