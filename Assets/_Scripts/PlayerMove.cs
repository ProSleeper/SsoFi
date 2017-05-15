using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 mouseMovePos;
    Vector3 mouseClickPos;
    Vector3 distance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseClickPos = Input.mousePosition;
            mouseClickPos = Camera.main.ScreenToWorldPoint(mouseClickPos);
            distance = this.gameObject.transform.position - mouseClickPos;
        }

        if(Input.GetMouseButton(0))
        {
            mouseMovePos = Input.mousePosition;
            mouseMovePos = Camera.main.ScreenToWorldPoint(mouseMovePos);
            this.transform.position =  mouseMovePos + distance;
        }

    }
}
