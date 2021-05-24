using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] spawnPoint;

    private float timeBtwSpawn;
    private int randLR;
    private float yL;
    private float yR;
    private float LowerTime = 1f;
    private float UpperTime = 2f;

    private void Start()
    {
        timeBtwSpawn = 1f;

    }

    void Update()
    {
        LevelManger enemySpeed = GameObject.Find("Main Camera").GetComponent<LevelManger>();
        LowerTime = enemySpeed.LowerTime;
        UpperTime = enemySpeed.UpperTime;
        
        yL = Random.Range(-3f, 1.5f);
        yR = Random.Range(-3f, 1.5f);
        Vector3 spawnL = new Vector3(-3.2f, yL, 0);
        Vector3 spawnR = new Vector3(3.2f, yR, 0);
        randLR = Random.Range(0, spawnPoint.Length);
        if (timeBtwSpawn <= 0)
        {
            if (randLR == 0)
            {
                Instantiate(spawnPoint[randLR], spawnL, Quaternion.identity);
                timeBtwSpawn = Random.Range(LowerTime, UpperTime);
                
            }
            else
            {
                Instantiate(spawnPoint[randLR], spawnR, Quaternion.identity);
                timeBtwSpawn = Random.Range(LowerTime, UpperTime);
                
            }

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

}
