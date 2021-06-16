
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine. SceneManagement;

public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update

    public Question[] questions;
    private static List<Question> unAnsQes;

    private Question currentQuestion;

    public Text questionText;

    public Text trueAnsText;

    public Text falseAnsText;

     [SerializeField]
    private Animator animator;

    private float timeBetweenQuestions=1f;

    void Start()
    {
        if(unAnsQes== null || unAnsQes.Count==0)
        {
            unAnsQes=questions.ToList<Question>();
        }

        GetRandomQuestion();
        
    }

    void GetRandomQuestion()
    {
        int randQesIndex= Random.Range(0, unAnsQes.Count);
        currentQuestion=unAnsQes[randQesIndex];

        questionText.text=currentQuestion.facts;

        if(currentQuestion.isTrue)
        {
            trueAnsText.text="CORRECT";
            falseAnsText.text="WRONG";
        }
        else
        {
            trueAnsText.text="WRONG";
            falseAnsText.text="CORRECT";
            
        }


    }

    IEnumerator transitionToNextQuestion()
    {
        unAnsQes.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    public void userSelectTrue()
    {
        animator.SetTrigger("True");
        
        if(currentQuestion.isTrue)
        {
            Debug.Log("Answer is True");
        }
        else
        {
            Debug.Log("Answer Is Wrong");
        }

        StartCoroutine(transitionToNextQuestion());
    }

     public void userSelectFalse()
    {
        
        animator.SetTrigger("False");

        if(!currentQuestion.isTrue)
        {
            Debug.Log("Answer is True");
        }
        else
        {
            Debug.Log("Answer Is Wrong");
        }

        StartCoroutine(transitionToNextQuestion());

    }
}
