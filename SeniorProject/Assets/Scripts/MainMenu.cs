using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        UpdateQuizButton();
    }
    public Button QuizMenuButton;
    public void UpdateCheckEngineModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckEngine = read;
        UpdateQuizButton();
    }

    public void UpdateCheckABSModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckABS = read;
        UpdateQuizButton();
    }

    public void UpdateCheckBrakePadsModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckBrakePads = read;
        UpdateQuizButton();
    }

    public void UpdateCheckBatteryModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckBattery = read;
        UpdateQuizButton();
    }

    public void UpdateCheckOilPressureModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckOilPressure = read;
        UpdateQuizButton();
    }

    public void UpdateCheckTirePressureModuleStatus(bool read)
    {
        PlayerInformation.Instance.PlayerReadCheckTirePressure = read;
        UpdateQuizButton();
    }

    public void UpdateQuizButton()
    {
        // If statement to check alll player information bools

        if(PlayerInformation.Instance.PlayerReadCheckEngine && PlayerInformation.Instance.PlayerReadCheckABS && 
            PlayerInformation.Instance.PlayerReadCheckBrakePads && PlayerInformation.Instance.PlayerReadCheckBattery && 
            PlayerInformation.Instance.PlayerReadCheckOilPressure && PlayerInformation.Instance.PlayerReadCheckTirePressure)
        {
            QuizMenuButton.enabled = true;
        }

        else
        {
            QuizMenuButton.enabled = false;
        }

        // If all done
        // Enable Button

        // If not done disable button
    }

    public void OpenQuizScene()
    {
        SceneManager.LoadScene(1);
    }
}
