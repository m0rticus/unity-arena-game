using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject adcMainPrefab;
    public GameObject godPrefab;
    public GameObject player;
    public float enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(adcMainPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyDied()
    {
        int number = Random.Range(0, 1000);
        if (number < 850)
        {
            SpawnEnemy();
        }
        else if (number < 950)
        {
            SpawnEnemy();
            SpawnEnemy();
        }
        else if (number < 990)
        {
            SpawnEnemy();
            SpawnEnemy();
            SpawnEnemy();
        }
        else if (number <= 1000)
        {
            SpawnEye();
        }
    }

    void SpawnEnemy()
    {
        float xSpawn = Random.Range(-45f, 45f);
        float ySpawn = Random.Range(-12f, 12f);
        if (Mathf.Abs(xSpawn - player.transform.position.x) > 30f && Mathf.Abs(ySpawn - player.transform.position.y) > 10f)
        {
            Instantiate(adcMainPrefab, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity);
        }
        else
        {
             SpawnEnemy();
        } 
    }

        void SpawnEye()
        {
        float xSpawn = Random.Range(-45f, 45f);
        float ySpawn = Random.Range(-12f, 12f);
        if (Mathf.Abs(xSpawn - player.transform.position.x) > 30f && Mathf.Abs(ySpawn - player.transform.position.y) > 10f)
        {
            Instantiate(godPrefab, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity);
        }
        else
        {
            SpawnEye();
        }
    }
}
