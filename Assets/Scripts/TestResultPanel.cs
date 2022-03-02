using System;
using DG.Tweening;
using Questions;
using UnityEngine;
using Views;
using Zenject;

public class TestResultPanel : MonoBehaviour
{
    [SerializeField] private ResultTestView resultTextView;
    [SerializeField] private RectTransform panel;
    [SerializeField] private float animationTime;
    
    private IQuestionsService _questionService;


    private void Start()
    {
        gameObject.SetActive(false);
    }

    [Inject]
    private void Construct(IQuestionsService questionsService)
    {
        _questionService = questionsService;
    }

    public void ShowResult(TestResult result)
    {
        gameObject.SetActive(true);
        
        panel.DOAnchorPos(Vector2.zero, animationTime).OnComplete(() =>
        {
            resultTextView.Show(result, _questionService.GetPath());
        });
    }
}
