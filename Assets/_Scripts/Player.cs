using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	Vector3 MouseMovePos;
	Vector3 MouseClickPos;
	Vector3 Distance;

	public Button btn;
	
	void Start()
	{
		btn.onClick.AddListener(Restart);
		btn.gameObject.SetActive(false);
		this.gameObject.tag = TAG_NAME.Player.ToString();
	}

	
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			MouseClickPos = Input.mousePosition;
			MouseClickPos = Camera.main.ScreenToWorldPoint(MouseClickPos);
			Distance = this.gameObject.transform.position - MouseClickPos;
		}

		if (Input.GetMouseButton(0))
		{
			//float s = 0;
			//float g = 1;
			//float dTime = 0;
			//dTime += Time.deltaTime * 10;
			//Time.timeScale = Mathf.Lerp(s, g, dTime / 2);
			//Debug.Log(Mathf.Lerp(s, g, dTime / 2));
			MouseMovePos = Input.mousePosition;
			MouseMovePos = Camera.main.ScreenToWorldPoint(MouseMovePos);
			this.transform.position = MouseMovePos + Distance;
		}
		else
		{
			//Time.timeScale = 5f;
			//dTime = 0;
		}
		ScreenLock();
		
	}
	
	void Restart()
	{
		btn.gameObject.SetActive(false);
		SceneManager.LoadScene(0);
	}

	//화면 밖으로 나가지 않게 하는 코드인데 실제 폰에서 잘 동작하지 않음 수정이 필요!!
	void ScreenLock()
	{
		Vector3 MinPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 MaxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (TagCheck.GetColl(this.tag, collision.tag))
		{
			Debug.Log("플레이어 충돌!");
			btn.gameObject.SetActive(true);
		}
	}
}
