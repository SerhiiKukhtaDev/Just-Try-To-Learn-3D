using System.Collections;
using DG.Tweening;
using UnityEngine;
using Utils;

public class QuestionSwapper : MonoBehaviour
{
    [SerializeField] private float time = 0.5f;
    [SerializeField] private Ease ease;

    private QuestionsMover _questionsMover;
    
    private float _lenght;
    private bool _canSwipe = true;

    private void Start()
    {
        _questionsMover = GetComponent<QuestionsMover>();
        _lenght = GetComponentInParent<Canvas>().GetCanvasHeightWithScaleFactor();
    }

    public void OnSwipeUp()
    {
        if (!_canSwipe) return;

        if (_questionsMover.TryMoveToPrevView())
        {
            _canSwipe = false;
            
            foreach (var questionView in _questionsMover.Views)
            {
                questionView.GetComponent<ItemScroll>().MoveUp(_lenght, time, ease);
            }
            
            StartCoroutine(WaitForSwipeEnd(time));
        }
    }

    public void OnSwipeDown()
    {
        if (!_canSwipe) return;

        if (_questionsMover.TryMoveToNextView())
        {
            _canSwipe = false;
            
            foreach (var questionView in _questionsMover.Views)
            {
                questionView.GetComponent<ItemScroll>().MoveDown(_lenght, time, ease);
            }
            
            StartCoroutine(WaitForSwipeEnd(time));
        }
    }

    private IEnumerator WaitForSwipeEnd(float swipeTime)
    {
        yield return new WaitForSeconds(swipeTime);

        _canSwipe = true;
    }
}
