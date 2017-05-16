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

			Vector3 MinPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
			Vector3 MaxPos = Camera.main.ScreenToWorldPoint(new Vector3(1440, 2560, 0));

			if(this.transform.position.x < MinPos.x)
			{
				this.transform.position = new Vector3(MinPos.x, this.transform.position.y, this.transform.position.z);
			}

			if (this.transform.position.x > MaxPos.x)
			{
				this.transform.position = new Vector3(MaxPos.x, this.transform.position.y, this.transform.position.z);
			}

			if (this.transform.position.y < MinPos.y)
			{
				this.transform.position = new Vector3(this.transform.position.x, MinPos.y, this.transform.position.z);
			}

			if (this.transform.position.y > MaxPos.y)
			{
				this.transform.position = new Vector3(this.transform.position.x, MaxPos.y, this.transform.position.z);
			}

		}
        if(Input.GetKeyDown(KeyCode.Space))
        {
			GameObject bullet = Resources.Load("Prefabs/Bullet") as GameObject;
			GameObject spawnEnemy = Instantiate(bullet, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			
		}
	}

}
