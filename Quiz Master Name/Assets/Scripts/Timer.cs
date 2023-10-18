using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float Flt_timeToCompleteQuestion = 30f;
    [SerializeField] float Flt_timeToShowCorrectAnswer = 10f;

    public bool Bol_isAnsweringQuestion = false;

    float Flt_timerValue;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        Flt_timerValue -= Time.deltaTime;

        if (Bol_isAnsweringQuestion )
        {
            if(Flt_timerValue <= 0)
            {
                Bol_isAnsweringQuestion = false;
                Flt_timerValue = Flt_timeToShowCorrectAnswer;
                Flt_timerValue = Flt_timeToCompleteQuestion;
            }
        }

        else
        {
            if(Flt_timerValue <= 0)
            {
                Bol_isAnsweringQuestion = true;
            }
        }

        Debug.Log(Flt_timerValue);
    }
}
