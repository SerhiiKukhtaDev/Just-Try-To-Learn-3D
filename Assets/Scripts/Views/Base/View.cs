using System;
using System.Collections.Generic;
using DG.Tweening;
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
        [SerializeField] private Image background;
        [SerializeField] private float animationDuration = 0.2f;

        public override event Action<View, bool> AnswerButtonClicked; 

        public override void Render(Question question)
        {
            questionTitle.text = question.Name;
            difficultyView.Render(question.Difficulty);
            
            foreach (var answer in question.Answers)
            {
                var item = Instantiate(template, answerParent);
                item.Render(answer);

                item.AnswerButtonClicked += OnAnswerButtonClick;
                
                AnswerButtons.Add(item);
            }
        }

        private void OnAnswerButtonClick(AnswerView answerView, bool isRightAnswer)
        {
            AnswerButtonClicked?.Invoke(this, isRightAnswer);

            background.DOFillAmount(1, 1f);
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
}
