using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerUpgradePanel : MonoBehaviour
{
    public GameObject rangeButton, firerateButton;
    public TMP_Text rangeText, firerateText;

    public void SetupPanel()
    {
        if(TowerManager.instance.selectedTower.upgrader.hasRangeUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            rangeText.text = "Upgrade\nRange\n(" + upgrader.rangeUpgrades[upgrader.curRangeUpgrade].cost + "G)";

            rangeButton.SetActive(true);
        }
        else
        {
            rangeButton.SetActive(false);
        }

        if (TowerManager.instance.selectedTower.upgrader.hasFirerateUpgrade)
        {
            TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;
            firerateText.text = upgrader.fireRateText + "\n(" + upgrader.firerateUpgrades[upgrader.curFirerateUpgrade].cost + "G)";

            firerateButton.SetActive(true);
        }
        else
        {
            firerateButton.SetActive(false);
        }
    }

    public void RemoveTower()
    {
        MoneyManager.instance.SpendMoney(-50);
        Destroy(TowerManager.instance.selectedTower.gameObject);
        UIController.instance.CloseTowerUpgradePanel();
        AudioManager.instance.PlaySFX(9);
    }

    public void UpgradeRange()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasRangeUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.rangeUpgrades[upgrader.curRangeUpgrade].cost))
            {
                upgrader.UpgradeRange();

                SetupPanel();

                UIController.instance.notEnouhMoneyWarning.SetActive(false);

                AudioManager.instance.PlaySFX(10);
            }
            else
            {
                UIController.instance.notEnouhMoneyWarning.SetActive(true);
            }
        }
    }

    public void UpgradeFireRate()
    {
        TowerUpgradeController upgrader = TowerManager.instance.selectedTower.upgrader;

        if (upgrader.hasFirerateUpgrade)
        {
            if (MoneyManager.instance.SpendMoney(upgrader.firerateUpgrades[upgrader.curFirerateUpgrade].cost))
            {
                upgrader.UpgradeFireRate();

                SetupPanel();

                UIController.instance.notEnouhMoneyWarning.SetActive(false);

                AudioManager.instance.PlaySFX(10);
            }
            else
            {
                UIController.instance.notEnouhMoneyWarning.SetActive(true);
            }
        }
    }
}
