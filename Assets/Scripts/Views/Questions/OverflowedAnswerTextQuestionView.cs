using System;
using System.Collections.Generic;
using Models;
using Views.Answers;
using Views.Base;

namespace Views.Questions
{
    public class OverflowedAnswerTextQuestionView : View<OverflowedAnswer>
    {
        public event Action<string> ShowOverflowedTextRequested;

        private List<OverflowedAnswer> _buttons;

        private void OnDisable()
        {
            _buttons.ForEach(b => b.ShowOverflowedText -= OnShowOverflowedTextRequested);
        }

        protected override OverflowedAnswer RenderItem(Answer answer)
        {
            _buttons = new List<OverflowedAnswer>();
           var item = base.RenderItem(answer);
           
           item.ShowOverflowedText += OnShowOverflowedTextRequested;
           _buttons.Add(item);

           return item;
        }

        private void OnShowOverflowedTextRequested(string obj)
        {
            ShowOverflowedTextRequested?.Invoke(obj);   
        }
    }
}
