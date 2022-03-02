using System;
using DG.Tweening;
using Lean.Gui;
using Models;
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

        public UnityEvent<ProgressInfo> questionAnswered;
        public UnityEvent<TestResult> lastQuestionAnswered;

        private int _rightAnswers;
        private int _allAnswersCount;

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

            _allAnswersCount++;
            view.SetAnswered();
            
            questionAnswered?.Invoke(new ProgressInfo(questionCreator.AllQuestionsCount, _allAnswersCount));

            if (isRightAnswer)
                _rightAnswers++;

            if (view.IsLastQuestion)
            {
                endTestButton.gameObject.SetActive(true);
                endTestButton.GetComponent<RectTransform>().DOAnchorPos(Vector2.zero, endTestButtonAppearTime);
            }
        }
    }

    [Serializable]
    public class ProgressInfo
    {
        public int AllQuestionsCount { get; }

        public int AnsweredQuestions { get; }

        public ProgressInfo(int allQuestionsCount, int answeredQuestions)
        {
            AllQuestionsCount = allQuestionsCount;
            AnsweredQuestions = answeredQuestions;
        }
    }
}
