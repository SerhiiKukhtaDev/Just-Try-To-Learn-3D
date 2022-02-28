using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Questions;
using UnityEngine;
using Utils;
using Views.Base;

public class QuestionSwapper : MonoBehaviour
{
    [SerializeField] private QuestionCreator questionCreator;

    [SerializeField] private float time = 0.5f;
    [SerializeField] private Ease ease;

    public event Action DownSwiped;
    public event Action UpSwiped;

    private float _lenght;
    private bool _canSwipe = true;
    private List<ItemScroll> _scrolls;

    private View _currentView;

    private void Awake()
    {
        _scrolls = new List<ItemScroll>();
    }

    private void Start()
    {
        _lenght = GetComponentInParent<Canvas>().GetCanvasHeightWithScaleFactor();
    }

    private void OnEnable()
    {
        questionCreator.QuestionCreated += OnQuestionCreated;
        questionCreator.CurrentViewChanged += OnViewChanged;
        questionCreator.ViewDestroyed += OnViewDestroyed;
    }

    private void OnViewDestroyed(View obj)
    {
        _scrolls.Remove(obj.GetComponent<ItemScroll>());
    }

    private void OnViewChanged(View obj)
    {
        _currentView = obj;
    }

    private void OnDisable()
    {
        questionCreator.QuestionCreated -= OnQuestionCreated;
        questionCreator.CurrentViewChanged -= OnViewChanged;
        questionCreator.ViewDestroyed -= OnViewDestroyed;
    }

    public void OnSwipeUp()
    {
        if(questionCreator.CurrentWatchableQuestion == 0) return;
        
        if(!_canSwipe) return;

        DoSwipeUp();

        StartCoroutine(WaitForSwipeEnd(time));
    }

    public void OnSwipeDown()
    {
        if(!_currentView.QuestionAnswered || _currentView.IsLastQuestion) return;

        if(!_canSwipe) return;

        DoSwipeDown();
        
        StartCoroutine(WaitForSwipeEnd(time));
    }

    private void DoSwipeUp()
    {
        _canSwipe = false;

        _scrolls.ForEach(s => s.MoveUp(_lenght, time, ease));
        
        UpSwiped?.Invoke();
    }

    private void DoSwipeDown()
    {
        DownSwiped?.Invoke();
        
        _canSwipe = false;
        _scrolls.ForEach(s => s.MoveDown(_lenght, time, ease));
    }

    private void OnQuestionCreated(View questionView)
    {
        _scrolls.Add(questionView.GetComponent<ItemScroll>());
    }

    private IEnumerator WaitForSwipeEnd(float swipeTime)
    {
        yield return new WaitForSeconds(swipeTime);

        _canSwipe = true;
    }
}
