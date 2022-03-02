using System;
using Database.Constants;
using Lean.Gui;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Views.Answers.Base;

namespace Views.Answers
{
    public class OverflowedAnswer : AnswerView
    {
        [SerializeField] private Text text;
        [SerializeField] private LeanButton showOverflowed;
        
        public event Action<string> ShowOverflowedText;
        
        public override void Render(Answer answer)
        {
            base.Render(answer);
            
            text.text = answer.AnswerText;
            showOverflowed.OnClick.AddListener(ShowOverflowed);
            
            if(text.text.Length < AnswerLenghtConstants.OverflowedSize)
                showOverflowed.gameObject.SetActive(false);
        }

        private void ShowOverflowed()
        {
            ShowOverflowedText?.Invoke(text.text);
        }
    }
}
