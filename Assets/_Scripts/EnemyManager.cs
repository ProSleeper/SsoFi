using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawnTime;


    private static EnemyManager _instance = null;

    public static EnemyManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("cSingleton == null");
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("EnemySpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition.x);
            Debug.Log(Input.mousePosition.y);
            Debug.Log(Input.mousePosition.z);
        }
    }

    void Spawn()
    {
        GameObject Enemy = Resources.Load("Prefabs/Enemy") as GameObject;
        Vector3 spawnPos = new Vector3(Random.Range(10, 1440), Random.Range(10, 2560), 0);
        spawnPos = Camera.main.ScreenToWorldPoint(spawnPos);

        GameObject spawnEnemy = Instantiate(Enemy, spawnPos, Quaternion.identity) as GameObject;
        spawnEnemy.transform.position = new Vector3(spawnEnemy.transform.position.x, spawnEnemy.transform.position.y, 0);
        spawnEnemy.transform.parent = this.transform;
    }

    IEnumerator EnemySpawn()
    {

        for(;;)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }

        
    }
}
