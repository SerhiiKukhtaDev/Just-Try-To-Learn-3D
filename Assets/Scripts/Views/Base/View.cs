using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Views.Answers.Base;
using Question = Models.Question;

namespace Views.Base
{
    public abstract class View<TAnswerView> : View where TAnswerView : AnswerView
    {
        [SerializeField] private Text questionTitle;
        [SerializeField] private TimeLeftView timeCounterView;
        [SerializeField] private Transform answerParent;
        [SerializeField] private TAnswerView template;
        [SerializeField] private DifficultyView difficultyView;
        [SerializeField] private DissolveBackgroundView dissolveView;
        [SerializeField] private float animationTime;

        private List<IReactOnAnswer> _reactOnAnswers;
        private bool _isAlreadyEntered;

        private void Start()
        {
            _reactOnAnswers = new List<IReactOnAnswer> {dissolveView};
        }

        public override event Action<View, bool> Answered; 

        public override void Render(Question question)
        {
            questionTitle.text = question.Name;
            difficultyView.Render(question.Difficulty);
            dissolveView.Render(1);
            timeCounterView.Render(difficultyView.Color, question.TimeToAnswer);
            
            question.GenerateRandomPositions();

            foreach (var item in question.Answers.Select(RenderItem))
            {
                AnswerButtons.Add(item);
            }
        }

        protected virtual TAnswerView RenderItem(Answer answer)
        {
            var item = Instantiate(template, answerParent);
            item.Render(answer);

            item.AnswerButtonClicked += OnAnswerButtonClick;

            return item;
        }

        private void OnAnswerButtonClick(AnswerView answerView, bool isRightAnswer)
        {
            Answer(isRightAnswer);

            answerView.AnswerButtonClicked -= OnAnswerButtonClick;
        }

        private void Answer(bool isRightAnswer)
        {
            QuestionAnswered = true;
            
            Answered?.Invoke(this, isRightAnswer);

            _reactOnAnswers.ForEach(r => r.React(isRightAnswer, animationTime));
            foreach (var viewAnswerButton in AnswerButtons) viewAnswerButton.OnAnswer();
            timeCounterView.EndCount();
        }

        public override void Enter()
        {
            if(_isAlreadyEntered) return;
            
            timeCounterView.StartCount(() => Answer(false));
            _isAlreadyEntered = true;
        }
    }

    public abstract class View : MonoBehaviour
    {
        public abstract void Render(Question question);

        public abstract void Enter();

        protected List<AnswerView> AnswerButtons { get; } = new List<AnswerView>();
        
        public abstract event Action<View, bool> Answered;

        public bool QuestionAnswered { get; protected set; }

        public void SetLast()
        {
            IsLastQuestion = true;
        }
        
        public bool IsLastQuestion { get; private set; }
    }

    public interface IReactOnAnswer
    {
        public void React(bool isRightAnswer, float time);
    }
}
