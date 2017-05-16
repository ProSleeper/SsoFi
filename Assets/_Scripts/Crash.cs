using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
	public Button btn;

    // Use this for initialization
    void Start()
    {
		btn.onClick.AddListener(Restart);
		btn.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("플레이어 충돌!");
		btn.gameObject.SetActive(true);

		//Destroy(this.gameObject);
	}

    // Update is called once per frame
    void Restart()
    {
		btn.gameObject.SetActive(false);
		SceneManager.LoadScene(0);
    }
}
