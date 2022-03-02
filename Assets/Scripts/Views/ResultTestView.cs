using System;
using DG.Tweening;
using Questions;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ResultTestView : MonoBehaviour
    {
        [SerializeField] private Text pathText;
        [SerializeField] private Text allQuestionsCount;
        [SerializeField] private Text rightAnswersCount;
        [SerializeField] private Image bar;
        [SerializeField] private float countTime;
        
        private void Start()
        {
            allQuestionsCount.text = 0.ToString();
            rightAnswersCount.text = 0.ToString();

            pathText.text = string.Empty;
        }

        public void Show(TestResult testResult, string subjectPath)
        {
            pathText.text = subjectPath;
            
            allQuestionsCount.DOCounter(0, testResult.AllAnswers, countTime).SetAutoKill();
            rightAnswersCount.DOCounter(0, testResult.RightAnswers, countTime).SetAutoKill();
            bar.DOFillAmount((float)testResult.RightAnswers / testResult.AllAnswers, countTime);
        }
    }
}
