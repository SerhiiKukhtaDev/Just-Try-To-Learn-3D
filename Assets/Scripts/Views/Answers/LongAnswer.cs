using Models;
using UnityEngine;
using UnityEngine.UI;
using Views.Answers.Base;

namespace Views.Answers
{
    public class LongAnswer : AnswerView
    {
        [SerializeField] private Text text;

        public override void Render(Answer answer)
        {
            base.Render(answer);
            
            text.text = answer.AnswerText;
        }
    }
}
