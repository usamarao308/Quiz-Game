
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update

    public Question[] questions;
    private static List<Question> unAnsQes;

    private Question currentQuestion;

    void Start()
    {
        if(unAnsQes== null || unAnsQes.Count==0)
        {
            unAnsQes=questions.ToList<Question>();
        }

        GetRandomQuestion();

        Debug.Log(currentQuestion.facts + " is "+ currentQuestion.isTrue);
        
    }

    void GetRandomQuestion()
    {
        int randQesIndex= Random.Range(0, unAnsQes.Count);
        currentQuestion=unAnsQes[randQesIndex];

        unAnsQes.RemoveAt(randQesIndex);


    }
}
