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
        [SerializeField] private QuestionViewCreator questionViewCreator;
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
            questionViewCreator.ViewCreated += OnQuestionCreated;
            endTestButton.OnClick.AddListener(OnEndButtonClicked);
        }

        private void OnDisable()
        {
            questionViewCreator.ViewCreated -= OnQuestionCreated;
            endTestButton.OnClick.RemoveListener(OnEndButtonClicked);
        }

        private void OnEndButtonClicked()
        {
            lastQuestionAnswered.Invoke(new TestResult(questionViewCreator.QuestionsCount(), _rightAnswers));
            endTestButton.gameObject.SetActive(false);
        }

        private void OnQuestionCreated(View obj)
        {
            obj.Answered += Answered;
        }

        private void Answered(View view, bool isRightAnswer)
        {
            view.Answered -= Answered;

            _allAnswersCount++;

            questionAnswered?.Invoke(new ProgressInfo(questionViewCreator.QuestionsCount(), _allAnswersCount));

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
