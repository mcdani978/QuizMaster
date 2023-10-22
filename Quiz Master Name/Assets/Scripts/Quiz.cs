

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int int_correctAnswerIndex;
    bool bol_hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite Spr_defaultAnswerSprite;
    [SerializeField] Sprite Spr_CorrectAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image Img_timerImage;
    Timer Tmr_timer;

    void Start()
    {
        Tmr_timer = FindObjectOfType<Timer>();
        GetNextQuestion();
        //DisplayQuestion();
    }

    void Update()
    {
        Img_timerImage.fillAmount = Tmr_timer.Flt_fillFraction;
        if (Tmr_timer.Bol_loadNextQuestion)
        {
            bol_hasAnsweredEarly = false;
            GetNextQuestion();
            Tmr_timer.Bol_loadNextQuestion = false;
        }
        else if(!bol_hasAnsweredEarly && !Tmr_timer.Bol_isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
        {
            bol_hasAnsweredEarly = true;
            DisplayAnswer(index);
            SetButtonState(false);
            Tmr_timer.CancelTimer();
        }

    void DisplayAnswer(int index)
    {
        Image Img_buttonImage;

        if (index == question.Int_GetCorrectAnswerIndex())
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


