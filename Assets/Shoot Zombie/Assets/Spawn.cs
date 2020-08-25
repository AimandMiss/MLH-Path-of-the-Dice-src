using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemy;
    public float spawnperiod = 1.5f;
    public float currentTime = 0f;

    void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime += 1 * Time.deltaTime;
      
        if (currentTime >= spawnperiod)
        {
            int randEnemy = Random.Range(0, enemy.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemy[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            currentTime = 0;
        }
    }
}
