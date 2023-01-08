using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    //public EnemyController enemyToSpawn;
    public EnemyController[] enemiesToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns;
    private float spawnCounter;

    public int amountToSpawn;

    public Castle castle;
    public Path path;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    void Update()
    {
        if(amountToSpawn > 0 && LevelManager.instance.levelActive)
        {
            spawnCounter -= Time.deltaTime;

            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;
                Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], spawnPoint.position, spawnPoint.rotation).Setup(castle, path);

                amountToSpawn--;
            }
        }
    }
}
