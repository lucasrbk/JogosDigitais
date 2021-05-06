using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemy;
    int randomSpawn, randomEnemy;
    public static bool spawnAllowed;
    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("spawnEnemy", 0f, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }

    void spawnEnemy()
    {
        if (spawnAllowed)
        {
            randomSpawn = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }
}
