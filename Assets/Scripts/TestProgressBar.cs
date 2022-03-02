using DG.Tweening;
using Questions;
using UnityEngine;
using UnityEngine.UI;

public class TestProgressBar : MonoBehaviour
{
    [SerializeField] private float animationTime;
    [SerializeField] private Image progressBar;
    
    public void SetValue(ProgressInfo info)
    {
        progressBar.DOFillAmount((float)info.AnsweredQuestions / info.AllQuestionsCount, animationTime);
    }
}
