using System;
using DG.Tweening;
using Lean.Gui;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Answers.Base
{
    public abstract class AnswerView : MonoBehaviour
    {
        [SerializeField] protected LeanButton answerButton;
        [SerializeField] protected Image cap;
        [SerializeField] protected Color rightAnswerColor;
        [SerializeField] private Color wrongAnswerColor;
        [SerializeField] private float fillTime;

        public event Action<AnswerView, bool> AnswerButtonClicked;

        private void OnDisable()
        {
            answerButton.OnClick.RemoveListener(OnAnswerClicked);
        }

        public virtual void Render(Answer answer)
        {
            IsRightAnswer = answer.IsRightAnswer;
            answerButton.OnClick.AddListener(OnAnswerClicked);
        }

        private void OnAnswerClicked()
        {
            AnswerButtonClicked?.Invoke(this, IsRightAnswer);
        }

        public bool IsRightAnswer { get; protected set; }

        public void OnAnswer()
        {
            answerButton.interactable = false;
            answerButton.enabled = false;
            
            cap.DOColor(IsRightAnswer ? rightAnswerColor : wrongAnswerColor, fillTime);
        }
    }
}
