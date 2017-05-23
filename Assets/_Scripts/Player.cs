using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MISSILE_TYPE
{
	MT_DEFAULT,
	MT_BIG,
	MT_EIGHTDIR,
	MT_ROUND,
	MT_ONEROUND,
	MT_CHASE,
	MT_MAX
}

public class Player : MonoBehaviour
{
	Vector3 mouseMovePos;
	Vector3 mouseClickPos;
	Vector3 distance;

	public Button btn;
	
	void Start()
	{
		btn.onClick.AddListener(Restart);
		btn.gameObject.SetActive(false);
	}
	
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
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
		ScreenLock();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			Debug.Log("플레이어 충돌!");
			btn.gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void Restart()
	{
		btn.gameObject.SetActive(false);
		SceneManager.LoadScene(0);
	}

	void ScreenLock()
	{
		Vector3 MinPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 MaxPos = Camera.main.ScreenToWorldPoint(new Vector3(1440, 2560, 0));

		if (this.transform.position.x < MinPos.x)
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
}
