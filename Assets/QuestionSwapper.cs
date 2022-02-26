using System.Collections.Generic;
using DG.Tweening;
using Factories;
using UnityEngine;
using Zenject;

public class QuestionSwapper : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private ScriptableObjects.Answers.Base.Question question;
    
    private List<ItemScroll> _questions;
    private Vector3 _currentQuestionPosition;
    private float _questionHeight;
    private IAnswerFactory _factory;
    
    [Inject]
    private void Construct(IAnswerFactory factory)
    {
        _factory = factory;
    }
    

    private void Start()
    {
        _questionHeight = Screen.height;
        _questions = new List<ItemScroll>();

        _factory.CreateWithRenderData(question, parent);
        
        /*var firstQuestion = Instantiate(template, parent);
        _questions.Add(firstQuestion);
        _currentQuestionPosition = firstQuestion.transform.position;
        
        CreateNextQuestion(_currentQuestionPosition);*/
    }

    public void MoveDown()
    {
        foreach (var question in _questions)
        {
            question.MoveDown(_questionHeight, 0.5f, Ease.Linear);
        }
    }

    public void MoveUp()
    {
        foreach (var question in _questions)
        {
            question.MoveUp(_questionHeight, 1f, Ease.Linear);
        }
    }

    private void CreateNextQuestion(Vector3 position)
    {
        /*var question = Instantiate(template, parent);
        question.MoveEnd += OnMoveEnd;

        _questions.Add(question);
        SetPositionByPreviousWith(question.transform, position, _questionHeight);*/
    }

    private void OnMoveEnd(Vector3 position, ItemScroll itemScroll)
    {
        CreateNextQuestion(position);
        itemScroll.MoveEnd -= OnMoveEnd;
    }

    private void SetPositionByPreviousWith(Transform target, Vector3 previousPosition, float delta)
    {
        target.position = new Vector3(previousPosition.x, previousPosition.y - delta, previousPosition.z);
    }
}
