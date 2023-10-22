using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int Int_correctAnswers = 0;
    int Int_questionsSeen = 0;

    public int Int_GetCorrectAnswers()
    {
        return Int_correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        Int_correctAnswers++;
    }

    public int Int_GetQuestionSeen()
    {
        return Int_questionsSeen;
    }

    public void IncrementQuestionSeen() 
    {
        Int_questionsSeen++;
    }

    public int Int_CalculateScore()
    {
        return Mathf.RoundToInt( Int_correctAnswers / (float)Int_questionsSeen * 100); // 3/4
    }
}
