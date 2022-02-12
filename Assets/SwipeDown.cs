using DG.Tweening;
using UnityEngine;

public class SwipeDown : MonoBehaviour
{
    [SerializeField] private RectTransform currentQuestion;
    [SerializeField] private RectTransform nextQuestion;
    [SerializeField] private Ease ease;
    [SerializeField] private float t;
    
    public void ToNext()
    {
        GoUpUp(currentQuestion, t);
        GoUp(nextQuestion, t);
    }

    public void ToBack()
    {
        GoDown(currentQuestion, t);
        GoDownDown(nextQuestion, t);
    }

    private void GoUp(RectTransform target, float time)
    {
        target.DOAnchorMin(new Vector2(0f, 0f), time).SetEase(ease);
        target.DOAnchorMax(new Vector2(1f, 1f), time).SetEase(ease);
    }

    private void GoUpUp(RectTransform target, float time)
    {
        target.DOAnchorMin(new Vector2(0f, 1f), time).SetEase(ease);
        target.DOAnchorMax(new Vector2(1f, 2f), time).SetEase(ease);
    }
    
    private void GoDown(RectTransform target, float time)
    {
        target.DOAnchorMin(new Vector2(0f, 0f), time).SetEase(ease);
        target.DOAnchorMax(new Vector2(1f, 1f), time).SetEase(ease);
    }

    private void GoDownDown(RectTransform target, float time)
    {
        target.DOAnchorMin(new Vector2(0f, -1f), time).SetEase(ease);
        target.DOAnchorMax(new Vector2(1f, 0f), time).SetEase(ease);
    }
}
