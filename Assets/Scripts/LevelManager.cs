using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool levelActive;
    private bool levelVictory;

    private Castle[] castles;

    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner simpleEnemySpawner;
    private EnemyWaveSpawner enemyWaveSpawner;

    public string nextLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        AudioManager.instance.PlayBackgroundMusic();

        castles = FindObjectsOfType<Castle>();
        enemyWaveSpawner = FindObjectOfType<EnemyWaveSpawner>();
        simpleEnemySpawner = FindObjectOfType<SimpleEnemySpawner>();

        levelActive = true;
    }

    void Update()
    {
        if(levelActive)
        {
            float totalCastleHealth = 0;
            foreach(Castle cast in castles)
            {
                totalCastleHealth += cast.currentHealth;
            }

            if(totalCastleHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;

                UIController.instance.levelFailedScreen.SetActive(true);
            }

            if(activeEnemies.Count == 0 && simpleEnemySpawner.amountToSpawn == 0 || activeEnemies.Count == 0 && enemyWaveSpawner.wavesToSpawn.Count == 0)
            {
                levelActive = false;
                levelVictory = true;

                UIController.instance.levelCompleteScreen.SetActive(true);
            }

            if(!levelActive)
            {
                UIController.instance.levelFailedScreen.SetActive(!levelVictory);
                UIController.instance.towerButtons.SetActive(levelActive);

                UIController.instance.CloseTowerUpgradePanel();
            }
        }
    }
}
