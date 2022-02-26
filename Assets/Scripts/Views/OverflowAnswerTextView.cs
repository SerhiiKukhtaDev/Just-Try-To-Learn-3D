using ScriptableObjects.Answers.Base;
using UnityEngine;
using UnityEngine.UI;
using Views.Base;
using Views.Interfaces.Base;

namespace Views
{
    public class OverflowAnswerTextView : View
    {
        [SerializeField] private Text question;
        [SerializeField] private Transform parent;
        [SerializeField] private OverflowedAnswerTemplate template;
        
        public override void Render(IContainQuestionData data)
        {
            question.text = data.QuestionTitle;
            
            foreach (var answer in data.Answers)
            {
                var item = Instantiate(template, parent);
                item.Text.text = answer;
            }
        }
    }
}
