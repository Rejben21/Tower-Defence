using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public TMP_Text goldText;
    public GameObject notEnouhMoneyWarning;

    public GameObject levelCompleteScreen, levelFailedScreen;

    public GameObject towerButtons;

    public string levelSelectScene, mainMenuScene;

    public GameObject pauseScreen;

    public TowerUpgradePanel towerUpgradePanel;

    public TMP_Text waveText;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void LevelSelect()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelSelectScene);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(LevelManager.instance.nextLevel);
    }

    public void OpenTowerUpgradePanel()
    {
        if (LevelManager.instance.levelActive)
        {
            towerUpgradePanel.gameObject.SetActive(true);
            towerUpgradePanel.SetupPanel();
        }
    }

    public void CloseTowerUpgradePanel()
    {
        towerUpgradePanel.gameObject.SetActive(false);

        if (TowerManager.instance.selectedTower != null)
        {
            TowerManager.instance.selectedTower.rangeModel.SetActive(false);
            TowerManager.instance.selectedTower = null;
        }

        TowerManager.instance.selectedTowerEffect.SetActive(false);

        notEnouhMoneyWarning.SetActive(false);
    }
}
