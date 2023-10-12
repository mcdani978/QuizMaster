using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Str_question = "Enter new question text here";
    [SerializeField] string[] Str_answers = new string[4];
    [SerializeField] int Int_CorrectAnswerIndex;

    public string Str_GetQuestion()
    {
        return Str_question;
    }

    public string GetAnswer(int index)
    {
        return Str_answers[index];
    }

    public int Int_GetCorrectAnswerIndex()
    { 
        return Int_CorrectAnswerIndex;
    }
}

