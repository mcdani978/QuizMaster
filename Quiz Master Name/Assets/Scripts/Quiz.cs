

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int int_correctAnswerIndex;
    [SerializeField] Sprite Spr_defaultAnswerSprite;
    [SerializeField] Sprite Spr_CorrectAnswerSprite;



    void Start()
    {
        GetNextQuestion();
      //DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
        {
            Image Img_buttonImage;

            if(index == question.Int_GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                Img_buttonImage = answerButtons[index].GetComponent<Image>();
                Img_buttonImage.sprite = Spr_CorrectAnswerSprite;
            }
            else
            {
                int_correctAnswerIndex = question.Int_GetCorrectAnswerIndex();
                string Str_Correctanswer = question.GetAnswer(int_correctAnswerIndex);
                questionText.text = "Sorry, the correct answer was;\n" + Str_Correctanswer;
                Img_buttonImage = answerButtons[int_correctAnswerIndex].GetComponent<Image>();
                Img_buttonImage.sprite = Spr_CorrectAnswerSprite;
            }
            SetButtonState(false);
        }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.Str_GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

        void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = Spr_defaultAnswerSprite;
        }
    }

    }


