using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float Flt_timeToCompleteQuestion = 30f;
    [SerializeField] float Flt_timeToShowCorrectAnswer = 10f;

    public bool Bol_loadNextQuestion;
    public bool Bol_isAnsweringQuestion = false;
    public float Flt_fillFraction;

    float Flt_timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        Flt_timerValue = 0;
    }

    void UpdateTimer()
    {
        Flt_timerValue -= Time.deltaTime;

        if (Bol_isAnsweringQuestion )
        {
            if(Flt_timerValue > 0)
            {
                Flt_fillFraction = Flt_timerValue / Flt_timeToCompleteQuestion; // 10/10 = 1
            }

            else
            {
                Bol_isAnsweringQuestion = false;
                Flt_timerValue = Flt_timeToShowCorrectAnswer;     
            }
        }

        else
        {
            if(Flt_timerValue > 0)
            {
                Flt_fillFraction = Flt_timerValue / Flt_timeToShowCorrectAnswer;
            }
            else
            {
                Bol_isAnsweringQuestion = true;
                Flt_timerValue = Flt_timeToCompleteQuestion;
                Bol_loadNextQuestion = true;
            }
        }

        Debug.Log(Bol_isAnsweringQuestion + ": " + Flt_timerValue + " = " + Flt_fillFraction);
    }
}
