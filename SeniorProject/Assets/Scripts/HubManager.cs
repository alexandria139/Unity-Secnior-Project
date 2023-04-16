using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    public HubWorldInteractableObject modules;
    public HubWorldInteractableObject choiceQuiz;
    public HubWorldInteractableObject carQuiz;

    public GameObject CongratsScreenGameObject;

    public TextMeshProUGUI CurrentTaskText;

    public string ModulesTask;
    public string ChoiceTask;
    public string CarTask;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CongratsScreenGameObject.SetActive(false);
        modules.ChangeInteractionAbility(true);
        choiceQuiz.ChangeInteractionAbility(false);
        carQuiz.ChangeInteractionAbility(false);
        
        if (!PlayerInformation.Instance.IsModuleCheckDone())
        {
            modules.SetAsNextStep();
            CurrentTaskText.text = ModulesTask;
        }
        
        else if (!PlayerInformation.Instance.IsMultChoiseDone())
        {
            choiceQuiz.ChangeInteractionAbility(true);
            choiceQuiz.SetAsNextStep();
            CurrentTaskText.text = ChoiceTask;
        }
        
        else if (!PlayerInformation.Instance.IsCarTestCompleted())
        {
            choiceQuiz.ChangeInteractionAbility(true);
            carQuiz.ChangeInteractionAbility(true);
            carQuiz.SetAsNextStep();
            CurrentTaskText.text = CarTask;
        }
        
        else
        {
            CongratsScreenGameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
