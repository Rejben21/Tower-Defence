using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public List<EnemyWave> wavesToSpawn;

    private float spawnCounter;
    public float waitForFirstSpawn;

    public Transform spawnPoint;

    public Castle castle;
    public Path path;

    public bool shouldSpawn = true;

    public float waveDisplayTime;
    private float waveDisplayCounter;
    private int waveCounter;

    void Start()
    {
        spawnCounter = waitForFirstSpawn;
        waveCounter = 1;
    }

    void Update()
    {
        if (shouldSpawn)
        {
            spawnCounter -= Time.deltaTime;
            if(spawnCounter <= 0)
            {
                if(wavesToSpawn[0].shouldDisplayWave)
                {
                    wavesToSpawn[0].shouldDisplayWave = false;

                    UIController.instance.waveText.gameObject.SetActive(true);
                    UIController.instance.waveText.text = "Wave " + waveCounter;
                    waveDisplayCounter = waveDisplayTime;
                }

                if(wavesToSpawn.Count > 0)
                {
                    if(wavesToSpawn[0].enemSpawnOrder.Count > 0)
                    {
                        Instantiate(wavesToSpawn[0].enemSpawnOrder[0], spawnPoint.position, spawnPoint.rotation).Setup(castle, path);

                        spawnCounter = wavesToSpawn[0].timeBetweenSpawns;

                        wavesToSpawn[0].enemSpawnOrder.RemoveAt(0);

                        if(wavesToSpawn[0].enemSpawnOrder.Count == 0)
                        {
                            spawnCounter = wavesToSpawn[0].timeToNextWave;

                            wavesToSpawn.RemoveAt(0);
                            waveCounter++;

                            if(wavesToSpawn.Count == 0)
                            {
                                shouldSpawn = false;
                            }
                        }
                    }
                }
            }

            if(waveDisplayCounter > 0)
            {
                waveDisplayCounter -= Time.deltaTime;
                if(waveDisplayCounter <= 0)
                {
                    UIController.instance.waveText.gameObject.SetActive(false);
                }
            }
        }
    }

    [System.Serializable]
    public class EnemyWave
    {
        public List<EnemyController> enemSpawnOrder = new List<EnemyController>(0);
        public float timeBetweenSpawns;
        public float timeToNextWave;
        [HideInInspector]
        public bool shouldDisplayWave = true;
    }
}
