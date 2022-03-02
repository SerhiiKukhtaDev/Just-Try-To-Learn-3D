using System;
using DG.Tweening;
using Questions;
using UnityEngine;
using Views;

public class TestResultPanel : MonoBehaviour
{
    [SerializeField] private ResultTestView resultTextView;
    [SerializeField] private RectTransform panel;
    [SerializeField] private float animationTime;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void ShowResult(TestResult result)
    {
        gameObject.SetActive(true);
        
        panel.DOAnchorPos(Vector2.zero, animationTime).OnComplete(() =>
        {
            resultTextView.Show(result);
        });
    }
}
