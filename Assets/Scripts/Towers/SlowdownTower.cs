using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownTower : MonoBehaviour
{
    private Tower tower;

    public Transform effectRing;

    void Start()
    {
        tower = GetComponent<Tower>();
    }

    void Update()
    {
        foreach(EnemyController enemy in tower.enemiesInRange)
        {
            enemy.speedMod = tower.fireRate;
        }

        effectRing.localScale = new Vector3(tower.range, 1f, tower.range);
    }
}
