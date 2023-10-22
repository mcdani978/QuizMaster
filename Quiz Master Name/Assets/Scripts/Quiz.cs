

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

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

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progessbar")]
    [SerializeField] Slider progressBar;

    public bool Bol_isComplete;

    void Start()
    {
        Tmr_timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
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
            scoreText.text = "Score: " + scoreKeeper.Int_CalculateScore() + "%";

            if(progressBar.value == progressBar.maxValue)
            {
                Bol_isComplete = true;
            }
        }

    void DisplayAnswer(int index)
    {
        Image Img_buttonImage;

        if (index == currentQuestion.Int_GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            Img_buttonImage = answerButtons[index].GetComponent<Image>();
            Img_buttonImage.sprite = Spr_CorrectAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            int_correctAnswerIndex = currentQuestion.Int_GetCorrectAnswerIndex();
            string Str_Correctanswer = currentQuestion.GetAnswer(int_correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was;\n" + Str_Correctanswer;
            Img_buttonImage = answerButtons[int_correctAnswerIndex].GetComponent<Image>();
            Img_buttonImage.sprite = Spr_CorrectAnswerSprite;
        }
    }

    void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementQuestionSeen();
        }
    }

    void GetRandomQuestion()
    {
        int int_index = Random.Range(0, questions.Count);
        currentQuestion = questions[int_index];

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.Str_GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
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


