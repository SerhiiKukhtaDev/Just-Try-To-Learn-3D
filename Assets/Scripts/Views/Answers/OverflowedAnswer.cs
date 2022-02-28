using Models;
using TMPro;
using UnityEngine;
using Views.Answers.Base;

namespace Views.Answers
{
    public class OverflowedAnswer : AnswerView
    {
        [SerializeField] private TMP_Text text;

        public override void Render(Answer answer)
        {
            base.Render(answer);
            
            text.text = answer.AnswerText;
        }
    }
}
