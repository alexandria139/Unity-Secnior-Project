using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarPartTest : MonoBehaviour
{
    public List<CarPartQuestion> Questions;

    public List<bool> Answers;

    public TextMeshProUGUI QuestionText;

    public TextMeshProUGUI QuestionResult;

    public GameObject TestResults;

    private int currentQuestion = 0;

    public bool questionProcessing { get; private set; } = false;

    public GameObject WrongAnswerParent;


    private void Start()
    {
        Answers = new List<bool>();
        QuestionResult.gameObject.SetActive(false);
        UpdateQuestion();
    }


    public void PlayerClickedOnPart(CarPart part)
    {
        if (questionProcessing) return;
        if (Questions[currentQuestion].CorrectPart == part)
        {
            Answers.Add(true);
        }

        else
        {
            Answers.Add(false);
        }

        StartCoroutine(QuestionAnswered());

    }


    private void UpdateQuestion()
    {
        QuestionText.text = Questions[currentQuestion].Question;
    }

    private IEnumerator QuestionAnswered()
    {
        questionProcessing = true;
        QuestionResult.gameObject.SetActive(true);

        if (Answers[currentQuestion])
        {
            QuestionResult.text = "Correct";
        }

        else
        {
            QuestionResult.text = "Wrong";
        }


        yield return new WaitForSecondsRealtime(2);
        
        foreach(CarPart carPart in GameObject.FindObjectsOfType<CarPart>())
        {
            carPart.DisableShader();
        }

        QuestionResult.gameObject.SetActive(false);

        if (currentQuestion >= Questions.Count - 1)
        {
            DisplayTestResults();
        }

        else
        {
            currentQuestion++;
            UpdateQuestion();

            questionProcessing = false;
        }


     
    }


    private void DisplayTestResults()
    {
        TestResults.gameObject.SetActive(true);
        GameObject wrongAnswers = TestResults.transform.Find("Wrong Answers").gameObject;
        int currentIncorectAnswer = 0;

        for (int i = 0; i < Answers.Count; i++)
        {
            if (Answers[i])
            {

            }

            else
            {
                var currentQuestion = Questions[i];
                var correctWrongAnswer = wrongAnswers.transform.GetChild(currentIncorectAnswer);
                correctWrongAnswer.gameObject.SetActive(true);

                correctWrongAnswer.GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.Question;
                correctWrongAnswer.transform.Find("Image").GetComponent<Image>().sprite = currentQuestion.CarPartImage;

                currentIncorectAnswer++;
            }
        }

        if(currentIncorectAnswer == 0)
        {
            PlayerInformation.Instance.CarPartTestCompleted = true;
        }

    }


    public void ReturnToQuizMenu()
    {
        SceneManager.LoadScene(1);
    }
}


[System.Serializable]
public class CarPartQuestion
{
    public CarPart CorrectPart;

    public string Question;

    public Sprite CarPartImage;
}
