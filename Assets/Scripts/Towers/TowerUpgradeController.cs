using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    private Tower tower;

    public UpgradeStage[] rangeUpgrades;
    public int curRangeUpgrade;
    public bool hasRangeUpgrade = true;

    public UpgradeStage[] firerateUpgrades;
    public int curFirerateUpgrade;
    public bool hasFirerateUpgrade = true;
    [TextArea]
    public string fireRateText;

    void Start()
    {
        tower = GetComponent<Tower>();
    }

    public void UpgradeRange()
    {
        tower.range = rangeUpgrades[curRangeUpgrade].amount;
        curRangeUpgrade++;
        if(curRangeUpgrade >= rangeUpgrades.Length)
        {
            hasRangeUpgrade = false;
        }
    }

    public void UpgradeFireRate()
    {
        tower.fireRate = firerateUpgrades[curFirerateUpgrade].amount;
        curFirerateUpgrade++;
        if (curFirerateUpgrade >= firerateUpgrades.Length)
        {
            hasFirerateUpgrade = false;
        }
    }
}

[System.Serializable]
public class UpgradeStage
{
    public float amount;
    public int cost;
}
