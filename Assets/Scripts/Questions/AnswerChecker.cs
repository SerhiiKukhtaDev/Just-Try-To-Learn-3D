using System;
using DG.Tweening;
using Lean.Gui;
using UnityEngine;
using UnityEngine.Events;
using Views.Base;

namespace Questions
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField] private QuestionCreator questionCreator;
        [SerializeField] private LeanButton endTestButton;
        [SerializeField] private float endTestButtonAppearTime = 0.5f;
        
        public UnityEvent<TestResult> lastQuestionAnswered;

        private int _rightAnswers;

        private void Start()
        {
            endTestButton.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            questionCreator.QuestionCreated += OnQuestionCreated;
            endTestButton.OnClick.AddListener(OnEndButtonClicked);
        }

        private void OnEndButtonClicked()
        {
            lastQuestionAnswered.Invoke(new TestResult(questionCreator.AllQuestionsCount, _rightAnswers));
            endTestButton.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            questionCreator.QuestionCreated -= OnQuestionCreated;
            endTestButton.OnClick.RemoveListener(OnEndButtonClicked);
        }

        private void OnQuestionCreated(View obj)
        {
            obj.AnswerButtonClicked += AnswerButtonClicked;
        }

        private void AnswerButtonClicked(View view, bool isRightAnswer)
        {
            view.AnswerButtonClicked -= AnswerButtonClicked;
            
            view.SetAnswered();

            if (isRightAnswer)
                _rightAnswers++;

            if (view.IsLastQuestion)
            {
                endTestButton.gameObject.SetActive(true);
                endTestButton.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, endTestButtonAppearTime);
            }
        }
    }

    public class TestResult
    {
        public int AllAnswers { get; }
        public int RightAnswers { get; }

        public TestResult(int allAnswers, int rightAnswers)
        {
            AllAnswers = allAnswers;
            RightAnswers = rightAnswers;
        }
    }
}
