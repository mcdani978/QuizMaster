using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string Str_question = "Enter new question text here";

    public string Str_GetQuestion()
    {
        return Str_question;
    }
}

