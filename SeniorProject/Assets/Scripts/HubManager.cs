using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HubManager : MonoBehaviour
{
    public HubWorldInteractableObject modules;
    public HubWorldInteractableObject choiceQuiz;
    public HubWorldInteractableObject carQuiz;

    public TextMeshProUGUI CurrentTaskText;

    public string ModulesTask;
    public string ChoiceTask;
    public string CarTask;
    // Start is called before the first frame update
    void Start()
    {
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

        else
        {
            choiceQuiz.ChangeInteractionAbility(true);
            carQuiz.ChangeInteractionAbility(true);
            carQuiz.SetAsNextStep();
            CurrentTaskText.text = CarTask;
        }


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
