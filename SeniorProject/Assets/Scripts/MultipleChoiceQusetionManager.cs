using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultipleChoiceQusetionManager : MonoBehaviour
{
    public List<Question> Questions;

    public Question.CorrectAnswerOptions CurrentlySelectedAnsewr;

    public Button SubmitButton;

    public Button NextButton;

    public List<Toggle> Options;

    public TextMeshProUGUI QuestionText;


    public int CurrentQuesition = 0;

    public TextMeshProUGUI QuestionExplanation;

    public GameObject ResultsScreen;

    public int numRequiredToPass;

    private void Start()
    {
        SetMenuOptionText();
    }

    private void SetMenuOptionText()
    {
        if(CurrentQuesition >= Questions.Count)
        {
            ShowReults();
            return;
        }
        SubmitButton.gameObject.SetActive(false);
        for(int i = 0; i < Options.Count; i++)
        {
            Transform toggleButton = Options[i].transform;

            Text labelText = toggleButton.Find("Label").gameObject.GetComponent<Text>();

            labelText.text = Questions[CurrentQuesition].GetAnswer((Question.CorrectAnswerOptions)i);

            toggleButton.transform.parent.Find("Red X").gameObject.SetActive(false);

            toggleButton.transform.parent.Find("Green Checkmark").gameObject.SetActive(false);

            Options[i].SetIsOnWithoutNotify(false);


        }

        NextButton.gameObject.SetActive(false);
        QuestionExplanation.gameObject.SetActive(false);
        QuestionText.text = Questions[CurrentQuesition].QuestionString;

    }

    public void Submit()
    {
        for(int i = 0; i < Options.Count; i++)
        {
            if((Question.CorrectAnswerOptions)i == Questions[CurrentQuesition].CorrectAnsewr)
            {
                Options[i].transform.parent.Find("Green Checkmark").gameObject.SetActive(true);
            }

            else
            {
                Options[i].transform.parent.Find("Red X").gameObject.SetActive(true);
            }
        }

        QuestionExplanation.gameObject.SetActive(true);

        if(Questions[CurrentQuesition].CorrectAnsewr == CurrentlySelectedAnsewr)
        {
            Questions[CurrentQuesition].GotQuestionCorrect = true;
            QuestionExplanation.text = "Correct";
        }

        else
        {
            Questions[CurrentQuesition].GotQuestionCorrect = false;
            QuestionExplanation.text = Questions[CurrentQuesition].Correction;
        }

        SubmitButton.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(true);
    }

    public void NextButtonClicked()
    {
        CurrentQuesition++;
        SetMenuOptionText();
    }
    public void ToggleButtonClicked(Toggle button)
    {
       foreach(Toggle toggle in Options)
        {
           toggle.SetIsOnWithoutNotify(false);

        }

        button.SetIsOnWithoutNotify(true);

        SubmitButton.gameObject.SetActive(true);


        string[] buttonNames = new string[] { "A", "B", "C", "D" };

        for(int i = 0; i < buttonNames.Length; i++)
        {
            if (button.gameObject.name.Equals($"ToggleButton {buttonNames[i]}"))
            {
                CurrentlySelectedAnsewr = (Question.CorrectAnswerOptions)i;
            }
        }

    }

    private void ShowReults()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        ResultsScreen.gameObject.SetActive(true);

        int numberOfCorrectOptions = 0;
        foreach(var answer in Questions)
        {
            if (answer.GotQuestionCorrect) numberOfCorrectOptions++;
        }

        string grade = numberOfCorrectOptions >= numRequiredToPass ? "Passed" : "Failed";
        var titleText = ResultsScreen.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        titleText.text = $"Results:\n{grade} {numberOfCorrectOptions}/{Questions.Count}";

        string correctionText = "";

        for(int i = 0; i < Questions.Count; i++)
        {
            if (!Questions[i].GotQuestionCorrect)
            {
                correctionText = $"{correctionText}\n\nQuestion {i + 1}: {Questions[i].QuestionString}\n<color=green>{Questions[i].Correction}</color>";
            }

        }

        ResultsScreen.transform.Find("Panel/Scroll Rect/Results Text").GetComponent<TextMeshProUGUI>().text = correctionText;
        if(numberOfCorrectOptions >= numRequiredToPass)
        {
            PlayerInformation.Instance.MultChoiceTestCompleted = true;
        }

        
    }
}
[System.Serializable]
public class Question
{
    [TextArea(10, 10)]
    public string QuestionString;

    [TextArea(2, 2)]
    public string AnswerA;

    [TextArea(2, 2)]
    public string AnswerB;

    [TextArea(2, 2)]
    public string AnswerC;

    [TextArea(2, 2)]
    public string AnswerD;

    [TextArea(2,2)]
    public string Correction;

    public enum CorrectAnswerOptions{A, B, C, D };

    public CorrectAnswerOptions CorrectAnsewr;

    /// <summary>
    /// Used for filling out the Toggle Buttons
    /// Will return the Option Text for the given option (A, B,C,D)
    /// </summary>
    /// <param name="option">Which option should be used</param>
    /// <returns></returns>
    public string GetAnswer(CorrectAnswerOptions option)
    {
        switch(option)
        {
            case CorrectAnswerOptions.A:
                return AnswerA;
            case CorrectAnswerOptions.B:
                return AnswerB;
            case CorrectAnswerOptions.C:
                return AnswerC;
            case CorrectAnswerOptions.D:
                return AnswerD;
            default:
                return "Situation not handled";
        }
    }

    [HideInInspector]
    public bool GotQuestionCorrect = false;

}
