using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTower : MonoBehaviour
{
    private Tower tower;

    public GameObject projectile;
    public Transform firePoint;
    //public float timeBetweenShots = 1f;
    private float shotCounter;

    private Transform target;
    public Transform launcherModel;

    public GameObject shotEffect;

    void Start()
    {
        tower = GetComponent<Tower>();
    }

    void Update()
    {
        if(target != null)
        {
            //launcherModel.LookAt(target);
            launcherModel.rotation = Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 15f * Time.deltaTime);
            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }

        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0 && target != null)
        {
            shotCounter = tower.fireRate;

            firePoint.LookAt(target);

            Instantiate(projectile, firePoint.position, firePoint.rotation);
            Instantiate(shotEffect, firePoint.position, Quaternion.identity);
        }

        if (tower.enemiesUpdated)
        {
            if (tower.enemiesInRange.Count > 0)
            {
                float minDistance = tower.range + 1f;
                foreach (EnemyController enemy in tower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }
            }
            else
            {
                target = null;
            }
        }
    }
}
