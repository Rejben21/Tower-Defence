using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3;
    public float fireRate;
    public LayerMask whatIsEnemy;

    private Collider[] collidersInRange;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();

    private float checkCounter;
    public float checkTime = .2f;

    [HideInInspector]
    public bool enemiesUpdated;

    public GameObject rangeModel;

    public int cost = 100;

    [HideInInspector]
    public TowerUpgradeController upgrader;

    void Start()
    {
        checkCounter = checkTime;

        upgrader = GetComponent<TowerUpgradeController>();
    }

    void Update()
    {
        enemiesUpdated = false;

        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;

            collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);

            enemiesInRange.Clear();
            foreach (Collider coll in collidersInRange)
            {
                enemiesInRange.Add(coll.GetComponent<EnemyController>());
            }

            enemiesUpdated = true;
        }

        if (TowerManager.instance != null)
        {
            if (TowerManager.instance.selectedTower == this)
            {
                rangeModel.SetActive(true);
                rangeModel.transform.localScale = new Vector3(range, 1f, range);
            }
        }
    }

    private void OnMouseDown()
    {
        if (LevelManager.instance.levelActive)
        {
            if (TowerManager.instance.selectedTower != null)
            {
                TowerManager.instance.selectedTower.rangeModel.SetActive(false);
            }

            TowerManager.instance.selectedTower = this;

            UIController.instance.OpenTowerUpgradePanel();

            TowerManager.instance.MoveTowerSelectionEffect();
        }
    }
}
