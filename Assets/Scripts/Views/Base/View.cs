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
        [SerializeField] private Transform answerParent;
        [SerializeField] private TAnswerView template;
        [SerializeField] private DifficultyView difficultyView;
        [SerializeField] private DissolveBackgroundView dissolveView;
        [SerializeField] private float animationTime;

        private List<IReactOnAnswer> _reactOnAnswers;

        private void Start()
        {
            _reactOnAnswers = new List<IReactOnAnswer> {dissolveView};
        }

        public override event Action<View, bool> AnswerButtonClicked; 

        public override void Render(Question question)
        {
            questionTitle.text = question.Name;
            difficultyView.Render(question.Difficulty);
            dissolveView.Render(1);
            
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
            AnswerButtonClicked?.Invoke(this, isRightAnswer);

            _reactOnAnswers.ForEach(r => r.React(isRightAnswer, animationTime));
            foreach (var viewAnswerButton in AnswerButtons) viewAnswerButton.OnAnswer();

            answerView.AnswerButtonClicked -= OnAnswerButtonClick;
        }
    }

    public abstract class View : MonoBehaviour
    {
        public abstract void Render(Question question);

        public List<AnswerView> AnswerButtons { get; } = new List<AnswerView>();
        
        public abstract event Action<View, bool> AnswerButtonClicked;

        public void SetAnswered()
        {
            QuestionAnswered = true;
        }
        
        public bool QuestionAnswered { get; private set; }

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
